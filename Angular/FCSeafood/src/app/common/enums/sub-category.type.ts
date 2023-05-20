export enum SubcategoryType {
  Unknown = 0,

  // Fish
  SeaFish = 1,
  RiverFish = 2,
  LakeFish = 3,

  // Cavier
  RedCaviar = 4,
  BlackSturgeonCaviar = 5,
  CodCaviar = 6,
  PikeCaviar = 7,

  // Seafood
  Mussels = 8,
  Squid = 9,
  Octopus = 10,
  Rapani = 11,
  SeafoodCocktail = 12,
  Shrimp = 13,
  LiveOyster = 14,
  CrabAndLobster = 15,
  Pectinida = 16
}

export const SubcategoryTypeValues = [
  {id: SubcategoryType.SeaFish, value: "sea-fish"},
  {id: SubcategoryType.RiverFish, value: "river-fish"},
  {id: SubcategoryType.LakeFish, value: "lake-fish"},

  {id: SubcategoryType.RedCaviar, value: "red-caviar"},
  {id: SubcategoryType.BlackSturgeonCaviar, value: "black-sturgeon-caviar"},
  {id: SubcategoryType.CodCaviar, value: "cod-caviar"},
  {id: SubcategoryType.PikeCaviar, value: "pike-caviar"},

  {id: SubcategoryType.Mussels, value: "mussels"},
  {id: SubcategoryType.Squid, value: "squid"},
  {id: SubcategoryType.Octopus, value: "octopus"},
  {id: SubcategoryType.Rapani, value: "rapani"},
  {id: SubcategoryType.SeafoodCocktail, value: "seafood-cocktail"},
  {id: SubcategoryType.Shrimp, value: "shrimp"},
  {id: SubcategoryType.LiveOyster, value: "live-oyster"},
  {id: SubcategoryType.CrabAndLobster, value: "crab-and-lobster"},
  {id: SubcategoryType.Pectinida, value: "pectinida"}
]
