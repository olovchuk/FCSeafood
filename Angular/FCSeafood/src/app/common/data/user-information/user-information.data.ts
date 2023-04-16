import {Injectable} from "@angular/core";
import {firstValueFrom} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {MatSnackBar} from "@angular/material/snack-bar";
import {GetUserInformationResponse} from "./models/response/get-user-information.response";
import {UserInformationDataSettings} from "./user-information.data.settings";

@Injectable({providedIn: 'root'})
export class UserInformationData {
  constructor(private http: HttpClient,
              private settings: UserInformationDataSettings,
              private snackBar: MatSnackBar) {
  }

  async GetUserInformationAsync(): Promise<GetUserInformationResponse> {
    const response = await firstValueFrom(this.http.get<GetUserInformationResponse>(this.settings.getUserInformationEndpointUrl));
    if (response.message)
      this.snackBar.open(response.message, 'close');

    return response;
  }
}
