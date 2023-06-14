import { CategoryTModel } from "@common-models/category-type.model";
import { SubcategoryTModel } from "@common-models/subcategory-type.model";
import { ItemStatusTModel } from "@common-models/item-status-type.model";
import { TemperatureUnitTModel } from "@common-models/temperature-unit-type.model";

export class ItemModel {
  id: string = ''; // guid
  name: string = '';
  code: string = '';
  imagePath: string = '';
  price: number = 0.0;
  category: CategoryTModel = new CategoryTModel();
  subcategory: SubcategoryTModel = new SubcategoryTModel();
  itemStatus: ItemStatusTModel = new ItemStatusTModel();
  quantityPerKg: number = 0.0;
  likeCount: number = 0.0;
  dislikeCount: number = 0.0;
  brand: string | null = null;
  type: string | null = null;
  finishing: string | null = null;
  isPackaging: boolean = true;
  fatsPer100Gram: number | null = null;
  carbohydratesPer100Gram: number | null = null;
  proteinsPer100Gram: number | null = null;
  kcalPer100Gram: number | null = null;
  humidityPerPercent: number | null = null;
  expirationDate: Date = new Date();
  temperatureStorage: number = 0.0;
  temperatureUnit: TemperatureUnitTModel = new TemperatureUnitTModel();
  description: string | null = null;
}
