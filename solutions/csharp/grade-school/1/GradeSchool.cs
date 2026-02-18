public class GradeSchool
{
    private Dictionary<string, int> _students = new();
    public bool Add(string student, int grade) => _students.TryAdd(student, grade);

    public IEnumerable<string> Roster() => _students.OrderBy(pair => pair.Value).ThenBy(pair => pair.Key).Select(pair => pair.Key);

    public IEnumerable<string> Grade(int grade) => _students.Where(pair => pair.Value == grade).OrderBy(pair => pair.Key).Select(pair => pair.Key);
}