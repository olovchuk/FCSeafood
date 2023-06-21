import { RatingType } from "@common-enums/rating.type";

export class SetItemRatingRequest {
  userId: string = ''; // Guid
  itemId: string = ''; // Guid
  ratingType: RatingType = RatingType.Unknown;
}
