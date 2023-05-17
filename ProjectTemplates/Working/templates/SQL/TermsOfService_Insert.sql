Declare @CreatedDate datetime
Declare @Latest bit
Declare @ToSText nvarchar(2000)

Set @CreatedDate = GETDATE()
Set @Latest = 1
Set @ToSText = 'Blazor Gallery Terms of Service

Blazor Gallery is a free site allowing graphics designers, photographers and 3D artists to showcase their portfolios.
By using this site, you agree to abide by all applicable laws and rules covered in these terms of service.

By uploading content, you agree that you have the right to upload and share all images being uploaded. 

This site is a demo for an opensource project, and therefore we do not allow nudity, pornography or adult themed content. 

Please ensure all images uploaded are safe to be shown in a work environment, and be tasteful. 

Any violations to these terms of service may result in account closure and your content being deleted from our servers.

This server is paid out of my own pocket, and I am not currently working, so any donations to help pay for storage and bandwidth will be appreciated.

Welcome to Blazor Gallery and I hope you enjoy this site.'

Exec TermsOfService_Insert @CreatedDate, @Latest, @ToSText