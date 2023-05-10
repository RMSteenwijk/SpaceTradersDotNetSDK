# SpaceTradersDotNetSDK

- Loosely based on the spotify api wrapper, built only for **v2** of SpaceTraders
- Should have all current endpoints and be easily update-able for future updates.
- All Data Models created using the OpenAPI tool

## Why?
The default generation from OpenAPI CLI isn't very developer friendly so I created this version for those that prefer an easier C# API.

## Usage

Without existing token:
1. dotnet add package SpaceTradersDotNetSDK
2. Create a client instance ```var spaceTraderClient = new SpaceTraderClient(httpClient, "");```
3. Create an Agent ```var registeredResponse = await spaceTraderClient.Register.Register(FactionType.COSMIC, "yourcallsign");```
4. Now update the client with ```spaceTraderClient.UpdateToken(registeredResponse.Token);```
5. Then proceed as normal to query ```var response = await spaceTraderClient.Fleet.GetMyShips(10, 1);```

With existing token:
1. dotnet add package SpaceTradersDotNetSDK
2. Create a client instance ```var spaceTraderClient = new SpaceTraderClient(httpClient, access_token);```
3. Query something ```var response = await spaceTraderClient.Fleet.GetMyShips(10, 1);```
