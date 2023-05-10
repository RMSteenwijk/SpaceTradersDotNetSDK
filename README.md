# SpaceTradersDotNetSDK

- Loosely based on the spotify api wrapper, built only for **v2** of SpaceTraders
- Should have all current endpoints and be easily update-able for future updates.
- All Data Models created using the OpenAPI tool

## Why?
The default generation from OpenAPI CLI isn't very developer friendly so I created this version for those that prefer an easier C# API.

## Usage



1. Git clone to local directory
2. Create new or locate your current spacetrader project
3. Add reference to the csproj file
```
<ItemGroup>
    <ProjectReference Include="..\SpaceTradersDotNetSDK\SpaceTradersDotNetSDK.csproj" />
</ItemGroup> 
```
4. Create a client instance ```var spaceTraderClient = new SpaceTraderClient(httpClient, access_token);```
5. Query something ```var response = await spaceTraderClient.Fleet.GetMyShips(10, 1);```
