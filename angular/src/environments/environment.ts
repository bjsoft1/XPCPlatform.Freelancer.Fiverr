import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'XPCPlatform',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44379/',
    redirectUri: baseUrl,
    clientId: 'XPCPlatform_App',
    responseType: 'code',
    scope: 'offline_access XPCPlatform',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44379',
      rootNamespace: 'XPCPlatform',
    },
  },

webUrl:
{
  HomePage: '',
  AdminPage: 'Auth/Admin/'
}

} as Environment;
