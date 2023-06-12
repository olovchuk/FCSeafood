import { RatingType } from "@common-enums/rating.type";

export class RatingResponse {
  isSuccessful: boolean = false;
  message: string = '';
  type: RatingType = RatingType.Unknown;
}
