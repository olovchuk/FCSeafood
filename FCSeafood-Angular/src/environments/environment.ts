export default interface IEnvironment {
  siteName: string;
  endPointsBaseUrl: string;
  allowedDomainsJWT: string[];
}

export const environment: IEnvironment = {
  siteName: 'Fresh Catch',
  endPointsBaseUrl: 'https://lc.fcseafood.com/webApi',
  allowedDomainsJWT: ['lc.fcseafood.com']
}
