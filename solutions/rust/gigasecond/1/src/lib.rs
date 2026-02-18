use time::PrimitiveDateTime as DateTime;
use time::ext::NumericalDuration;

// Returns a DateTime one billion seconds after start.
pub fn after(start: DateTime) -> DateTime {
    let end = start
        .checked_add(1_000_000_000_i64.seconds());

    return end.expect("Failed to add one billion seconds");
}
