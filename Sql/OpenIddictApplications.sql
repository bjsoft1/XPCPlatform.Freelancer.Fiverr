-- Insert for XPCPlatform_Web
INSERT INTO OpenIddictApplications 
    (Id, ClientId, ClientSecret, DisplayName, RedirectUris, ClientUri, Type, CreationTime, ExtraProperties, ConcurrencyStamp)
VALUES 
    (NEWID(), 'XPCPlatform_Web', '1q2w3e*', 'XPCPlatform_Web', 'https://localhost:44349', 'https://localhost:44349', 'YOUR_CLIENT_TYPE', GETDATE(), '{}', '');

-- Insert for XPCPlatform_App
INSERT INTO OpenIddictApplications 
    (Id, ClientId, ClientSecret, DisplayName, RedirectUris, ClientUri, Type, CreationTime, ExtraProperties, ConcurrencyStamp)
VALUES 
    (NEWID(), 'XPCPlatform_App', '1q2w3e*', 'XPCPlatform_App', 'http://localhost:4200', 'http://localhost:4200', 'YOUR_CLIENT_TYPE', GETDATE(), '{}', '');

-- Insert for XPCPlatform_BlazorServerTiered
INSERT INTO OpenIddictApplications 
    (Id, ClientId, ClientSecret, DisplayName, RedirectUris, ClientUri, Type, CreationTime, ExtraProperties, ConcurrencyStamp)
VALUES 
    (NEWID(), 'XPCPlatform_BlazorServerTiered', '1q2w3e*', 'XPCPlatform_BlazorServerTiered', 'https://localhost:44316', 'https://localhost:44316', 'YOUR_CLIENT_TYPE', GETDATE(), '{}', '');

-- Insert for XPCPlatform_Swagger
INSERT INTO OpenIddictApplications 
    (Id, ClientId, DisplayName, RedirectUris, ClientUri, Type, CreationTime, ExtraProperties, ConcurrencyStamp)
VALUES 
    (NEWID(), 'XPCPlatform_Swagger', 'XPCPlatform_Swagger', 'https://localhost:44385', 'https://localhost:44385', 'YOUR_CLIENT_TYPE', GETDATE(), '{}', '');
