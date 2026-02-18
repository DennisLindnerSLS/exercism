//! A module for a 24-hour clock that supports normalization and arithmetic.
use std::fmt::Display;

/// Represents a 24-hour clock with hours and minutes.
#[derive(Debug)]
pub struct Clock {
    hours: i32,
    minutes: i32,
}

impl Clock {
    /// Creates a new `Clock` instance, normalizing the input hours and minutes.
    ///
    /// # Arguments
    /// * `hours` - The hour value, can be any integer (positive or negative).
    /// * `minutes` - The minute value, can be any integer (positive or negative).
    ///
    /// # Returns
    /// A normalized `Clock` representing the correct time on a 24-hour clock.
    pub fn new(hours: i32, minutes: i32) -> Self {
        let total_minutes = hours * 60 + minutes;
        let normalize_minutes = Clock::normalize_minutes(total_minutes);

        return Clock {
            hours: normalize_minutes / 60,
            minutes: normalize_minutes % 60,
        };
    }

    /// Returns a new `Clock` with the specified number of minutes added.
    ///
    /// # Arguments
    /// * `minutes` - The number of minutes to add (can be negative).
    ///
    /// # Returns
    /// A new `Clock` with the time adjusted accordingly.
    pub fn add_minutes(&self, minutes: i32) -> Self {
        // Calculate the new time by adding minutes and adjusting for overflow
        let total_minutes = self.hours * 60 + self.minutes + minutes;
        let normalize_minutes = Clock::normalize_minutes(total_minutes);
        
        return Clock{
            hours: normalize_minutes / 60,
            minutes: normalize_minutes % 60,
        }
    }

    /// Normalizes a minute value to fit within a 24-hour clock.
    ///
    /// # Arguments
    /// * `minutes` - The minute value to normalize.
    ///
    /// # Returns
    /// An integer representing the normalized minutes within a 24-hour period.
    fn normalize_minutes(minutes: i32) -> i32 {
        return ((minutes % (24 * 60)) + (24 * 60)) % (24 * 60);
    }
}

impl PartialEq for Clock {
    fn eq(&self, other: &Self) -> bool {
        self.hours == other.hours && self.minutes == other.minutes
    }
}

impl Display for Clock {
    fn fmt(&self, f: &mut std::fmt::Formatter<'_>) -> std::fmt::Result {
        write!(f, "{:02}:{:02}", self.hours, self.minutes)
    }
}