#[derive(Debug, PartialEq, Eq)]
pub enum Error {
    InvalidInputBase,
    InvalidOutputBase,
    InvalidDigit(u32),
}

///
/// Convert a number between two bases.
///
/// A number is any slice of digits.
/// A digit is any unsigned integer (e.g. u8, u16, u32, u64, or usize).
/// Bases are specified as unsigned integers.
///
/// Return the corresponding Error enum if the conversion is impossible.
///
///
/// You are allowed to change the function signature as long as all test still pass.
///
///
/// Example:
/// Input
///   number: &[4, 2]
///   from_base: 10
///   to_base: 2
/// Result
///   Ok(vec![1, 0, 1, 0, 1, 0])
///
/// The example corresponds to converting the number 42 from decimal
/// which is equivalent to 101010 in binary.
///
///
/// Notes:
///  * The empty slice ( "[]" ) is equal to the number 0.
///  * Never output leading 0 digits, unless the input number is 0, in which the output must be `[0]`.
///    However, your function must be able to process input with leading 0 digits.
///
pub fn convert(number: &[u32], from_base: u32, to_base: u32) -> Result<Vec<u32>, Error> {
    match (from_base, to_base) {
        (x, _) if x < 2 => return Err(Error::InvalidInputBase),
        (_, y) if y < 2 => return Err(Error::InvalidOutputBase),
        _ => { /* continue with conversion */ }
    }

    to_base10(number, from_base)
        .and_then(|mut base10| base10_to_base(&mut base10, &to_base))

}

pub fn to_base10(number: &[u32], from_base: u32) -> Result<u32, Error> {
    number.iter()
        .enumerate()
        .try_fold(0u32, |acc, (idx, &n)| {
            if n >= from_base {
                return Err(Error::InvalidDigit(n));
            }
            from_base.checked_pow((number.len() - idx - 1) as u32)
                .and_then(|pow| n.checked_mul(pow))
                .and_then(|mul| acc.checked_add(mul))
                .ok_or(Error::InvalidDigit(n))
        }
    )
}

pub fn base10_to_base(number: &mut u32, to_base: &u32) -> Result<Vec<u32>, Error> {
    println!("number: {}, base: {}",*number, *to_base);
    if *to_base < 2 {
        return Err(Error::InvalidOutputBase);
    }
    if *number == 0 {
        return Ok(vec![0]);
    }

    let mut digits: Vec<u32> = std::iter::from_fn(move || {
        if *number == 0 {
            return None;
        }
        let r = *number % to_base;
        *number /= to_base;
        Some(r)
    }).collect();

    digits.reverse();
    Ok(digits)
}