pub struct Allergies {
    score: u32,
}

#[derive(Debug, PartialEq, Eq, Copy, Clone)]
pub enum Allergen {
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128,
}

impl Allergies {
    pub fn new(score: u32) -> Self {
        Self { score: score & 0xFF }//only take the 8 bits we care about (requires update if we add allergens, so maybe not the best solution)
    }

    pub fn is_allergic_to(&self, allergen: &Allergen) -> bool {
        self.score & *allergen as u32 != 0
    }

    pub fn allergies(&self) -> Vec<Allergen> {
        (0..8)
            .filter_map(|i| {
                let flag = 1 << i;
                if self.score & flag != 0 {
                    Self::number_to_allergen(&flag)
                } else {
                    None
                }
            })
            .collect::<Vec<Allergen>>()
    }

    fn number_to_allergen(allergen: &u32) -> Option<Allergen> {
        match allergen {
            1 => Some(Allergen::Eggs),
            2 => Some(Allergen::Peanuts),
            4 => Some(Allergen::Shellfish),
            8 => Some(Allergen::Strawberries),
            16 => Some(Allergen::Tomatoes),
            32 => Some(Allergen::Chocolate),
            64 => Some(Allergen::Pollen),
            128 => Some(Allergen::Cats),
            _ => None
        }
    }
}
