import { RatingType } from "@common-enums/rating.type";

export class RatingTResponse {
  isSuccessful: boolean = false;
  message: string = '';
  type: RatingType = RatingType.Unknown;
}
