import {environment} from "@environments/environment";
import ISettings from "./ISettings";

export const AppSettings: ISettings = {
  siteName: environment.siteName,
  webApiHostUrl: environment.endPointsBaseUrl,
  allowedDomainsJWT: environment.allowedDomainsJWT
}
