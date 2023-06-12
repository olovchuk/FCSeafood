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
  brand: string = '';
  type: string = '';
  finishing: string = '';
  isPackaging: boolean = true;
  fatsPer100Gram: number = 0.0;
  carbohydratesPer100Gram: number = 0.0;
  proteinsPer100Gram: number = 0.0;
  kcalPer100Gram: number = 0.0;
  humidityPerPercent: number = 0.0;
  expirationDate: Date = new Date();
  temperatureStorage: number = 0.0;
  temperatureUnit: TemperatureUnitTModel = new TemperatureUnitTModel();
  description: string = '';
}
