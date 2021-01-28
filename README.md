![alt text](https://github.com/Viincenttt/MollieApi/workflows/Run%20automated%20tests/badge.svg "Automated Tests")

# RealoAPI for Dotnet Core in C#

An unofficial .NET wrapper for the Realo.be API.

## Contributions

Have you spotted a bug or want to add a missing feature? All pull requests are welcome! Please provide a description of the bug or feature you have fixed/added. Make sure to target the latest development branch.

## 1. Installation

The easiest way to install is through the [NuGet](https://www.nuget.org/packages/RealoAPI/) package.
```
PM> Install-Package RealoAPI
```

## 2. Library limitations

The library has currently some limitations, only listings are currently supported.

- Get all listings
- Create a new listing
- Retreive a listing
- Update a listing
- Cancel a listing
- Add one/multiple pictures
- Moving a picture
- Delete a picture
- Publish a listing

## 3. Documentation

Official documentation can be found on the [Realo](https://api.realo.com/docs) API documentation.

## Examples
### Basic Example
```cs
RealoClient client = new RealoClient("private_key", "public_key");

int agencyId = 1;
Listing listing = new Listing(ListingType.APARTMENT, ListingWay.SALE);

//Post the listing
int listingId = client.Listings.Add(listing, agencyId);

//Publish the new listing
client.Listings.Publish(listingId);
```
This only contains the most basic options, there are a lot more, the documentation will get updated soon.