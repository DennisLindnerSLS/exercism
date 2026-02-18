using System;
using System.Collections.Generic;
using System.Linq;

public static class TelemetryBuffer
{

    public static byte[] ToBuffer(long reading)
    {
        bool isUnsigned = IsUnsigned(reading);

        var requiredNumberOfBytes = BytesRequiredForUnsignedNumber(reading);
        List<byte> bytes = new();
    
        if(!isUnsigned){
            uint val = 256 - requiredNumberOfBytes;
            bytes.Add((byte)(val & 0xFF));
        }else{
            bytes.Add((byte)(requiredNumberOfBytes & 0xFF));
        }

        ulong unsignedReading = (ulong)reading;
        for(int i = 0; i < requiredNumberOfBytes; i++){
            byte currentByte = (byte)(unsignedReading & 0xFF); //get right most byte
            bytes.Add(currentByte);
            unsignedReading >>= 8; //shift right by one byte
        } 

        //fill up last
        while(bytes.Count < 9)
            bytes.Add(0);
        
        return bytes.ToArray();
    }

    public static long FromBuffer(byte[] buffer)
    {
        byte signedByte = buffer[0];

        if(signedByte != 2 
           && signedByte != 4 
           && signedByte != 8 
           && signedByte != 254 
           && signedByte != 252 
           && signedByte != 248)
        {
            return 0;
        }
        
        switch(signedByte){
            case 2: return (long)BitConverter.ToUInt16(buffer[1..3], 0);
            case 4: return (long)BitConverter.ToUInt32(buffer[1..5], 0);
            case 8: return (long)BitConverter.ToUInt64(buffer[1..9], 0);
            case 254: return (long)BitConverter.ToInt16(buffer[1..3], 0);
            case 252: return (long)BitConverter.ToInt32(buffer[1..5], 0);
            case 248: return (long)BitConverter.ToInt64(buffer[1..9], 0);
            default: return 0;
        }
    }

    private static bool IsUnsigned(long reading){
        return (reading >= 0 && reading <= 65535)
            || (reading >= 2147483648 && reading <= 4294967295)
            || (reading > 9223372036854775807);
    }
    
    private static uint BytesRequiredForUnsignedNumber(long number)
    {
        if(number >= -32768 && number <= 65535)
            return 2;
        else if(number >= -2147483648 && number <= 4294967295)
            return 4;
        else 
            return 8;
    }

}
