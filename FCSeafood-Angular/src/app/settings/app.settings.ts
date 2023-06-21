import { environment } from "@environments/environment";

export default interface ISettings {
  siteName: string;
  webApiHostUrl: string;
  allowedDomainsJWT: string[];
}

export const AppSettings: ISettings = {
  siteName: environment.siteName,
  webApiHostUrl: environment.endPointsBaseUrl,
  allowedDomainsJWT: environment.allowedDomainsJWT
}
