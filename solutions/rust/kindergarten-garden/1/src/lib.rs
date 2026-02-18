
const STUDENTS: [&str; 12] = [
    "Alice", "Bob", "Charlie", "David", "Eve", "Fred", "Ginny", "Harriet",
    "Ileana", "Joseph", "Kincaid", "Larry",
];

pub fn plants(diagram: &str, student: &str) -> Vec<&'static str> {
  let mut students = STUDENTS.to_vec();
  students.sort();

  let index = students.iter()
    .position(|&s| s == student)
    .and_then(|i| i.checked_mul(2))
    .filter(|&i| i < diagram.lines().next().map_or(0, |line| line.len()));

  let index = match index {
    Some(i) => i,
    None => return vec![],
  };

  diagram.lines()
    .flat_map(|line| {
    line.chars()
        .skip(index)
        .take(2)
        .map(|c| match c {
            'C' => "clover",
            'G' => "grass",
            'R' => "radishes",
            'V' => "violets",
            _ => "",
        })
        .collect::<Vec<&str>>()
  })
  .collect()
}
