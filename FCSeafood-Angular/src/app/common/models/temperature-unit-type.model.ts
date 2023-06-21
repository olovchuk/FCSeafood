import { TemperatureUnitType } from "@common-enums/temperature-unit.type";

export class TemperatureUnitTModel {
  type: TemperatureUnitType = TemperatureUnitType.Unknown;
  sign: string = '';
  name: string = '';
}
