using System;
using System.Collections.Generic;

namespace RealoAPI.Models {

    public class Listing {

        /// <summary>
        /// Unique identifier.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Property type.
        /// </summary>
        public ListingType Type { get; set; }

        /// <summary>
        /// Secondary Type.
        /// </summary>
        public EstateSecundairyType? SecundairyType { get; set; }

        /// <summary>
        /// State of the building.
        /// </summary>
        public BuildingCondition? BuildingCondition { get; set; }

        /// <summary>
        /// Listing type.
        /// </summary>
        public ListingWay Way { get; set; }

        /// <summary>
        /// Listing status.
        /// </summary>
        public ListingStatus? Status { get; set; }

        /// <summary>
        /// Indicates if this is a featured/promoted listing.
        /// </summary>
        public bool Featured { get; private set; }

        /// <summary>
        /// Start date and time of the listing.
        /// </summary>
        public DateTime? ListedAt { get; set; }

        /// <summary>
        /// Modification date and time of the listing.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Availability date of the listing.
        /// </summary>
        public DateTime? AvailableAt { get; set; }

        /// <summary>
        /// An list of descriptions by language code.
        /// </summary>
        public IDictionary<Language, string> Description { get; set; }

        /// <summary>
        /// An list of titles by language code.
        /// </summary>
        public IDictionary<Language, string> Title { get; set; }

        /// <summary>
        /// Property agency.
        /// </summary>
        public Agency Agency { get; private set; }

        /// <summary>
        /// Property address.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Show or hide the address on Realo.
        /// </summary>
        public bool? AddressVisible { get; set; }

        /// <summary>
        /// Property price, without formatting.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Currency of the price.
        /// </summary>
        public Currency? Currency { get; set; }

        /// <summary>
        /// Whether to show or hide the price on Realo.
        /// </summary>
        public bool? PriceVisible { get; set; }

        /// <summary>
        /// Monthly extra costs in the same currency as the price.
        /// </summary>
        public int? MonthlyFixedCosts { get; set; }

        /// <summary>
        /// Floor where the estate is located. Floor 0 represents the ground floor.
        /// </summary>
        public int? Floor { get; set; }

        /// <summary>
        /// Total number of floors of the building where the property is located.
        /// </summary>
        public int? NumberOfFloors { get; set; }

        /// <summary>
        /// Habitable size in square meters.
        /// </summary>
        public float? HabitableArea { get; set; }

        /// <summary>
        /// Land size in square meters.
        /// </summary>
        public float? LandArea { get; set; }

        /// <summary>
        /// Number of bedrooms.
        /// </summary>
        public int? NumberOfBedrooms { get; set; }

        /// <summary>
        /// Number of bathrooms.
        /// </summary>
        public int? NumberOfBathrooms { get; set; }

        /// <summary>
        /// Number of toilets.
        /// </summary>
        public int? NumberOfToilets { get; set; }

        /// <summary>
        /// Number of garages (i.e. number of parking spaces in the garages).
        /// </summary>
        public int? NumberOfGarages { get; set; }

        /// <summary>
        /// Number of outdoor parking spaces.
        /// </summary>
        public int? NumberOfParkingSpaces { get; set; }

        /// <summary>
        /// Original build year.
        /// </summary>
        public int? BuildYear { get; set; }

        /// <summary>
        /// Year of the last renovation.
        /// </summary>
        public int? RenovationYear { get; set; }

        /// <summary>
        /// Cadastral income in the same currency as the price.
        /// </summary>
        public int? CadastralIncome { get; set; }

        /// <summary>
        /// Energy consumption in kWh/m².
        /// </summary>
        public float? EnergyConsumption { get; set; }

        /// <summary>
        /// Energy consumption in kWh/y.
        /// </summary>
        public float? EnergyConsumptionYearly { get; set; }

        /// <summary>
        /// Energy certificate number.
        /// </summary>
        public string EnergyCertificateNumber { get; set; }

        /// <summary>
        /// European classification for energy performance.
        /// See https://en.wikipedia.org/wiki/Energy_Performance_Certificate.
        /// </summary>
        public EnergyClassification? EnergyClassification { get; set; }

        /// <summary>
        /// CO² emissions in kg/m².
        /// </summary>
        public int? Co2Emissions { get; set; }

        /// <summary>
        /// Width of the front facade in meters.
        /// </summary>
        public float? FacadeWidth { get; set; }

        /// <summary>
        /// Estate detachment type.
        /// </summary>
        public EstateDetachment? Detachment { get; set; }

        /// <summary>
        /// Primary heating type.
        /// </summary>
        public EstateHeatingType? HeatingType { get; set; }

        /// <summary>
        /// Orientation of the garden.
        /// </summary>
        public Orientation? GardenOrientation { get; set; }

        /// <summary>
        /// Electricity inspection report type.
        /// </summary>
        public ElectricityInspectionReportType? ElectricityInspectionReportType { get; set; }

        /// <summary>
        /// Indicates if the estate is in a flood prone location.
        /// </summary>
        public EstateFloodProneLocation FloodProneLocation { get; set; }

        /// <summary>
        /// Indicates if the estate is in a delineated area.
        /// </summary>
        public EstateDelineatedArea DelineatedArea { get; set; }

        /// <summary>
        /// A list of additional properties of this estate. The true/false value indicates if a flag is available or not available.
        /// </summary>
        public IDictionary<string, bool> Flags { get; set; }

        /// <summary>
        /// List of pictures.
        /// </summary>
        public List<Picture> Pictures { get; private set; }

        /// <summary>
        /// List of virtual tours.
        /// </summary>
        public List<VirtualTour> VirtualTours { get; set; }

        /// <summary>
        /// List of Realo urls by language.
        /// </summary>
        public IDictionary<Language, string> CanonicalUrls { get; private set; }

        /// <summary>
        /// Original agency website url of the listing or a list of agency urls by language code.
        /// </summary>
        public IDictionary<Language, string> AgencyUrl { get; set; }

        /// <summary>
        /// A reference to the original listing of the agency.
        /// </summary>
        public int? AgencyReference { get; set; }

        /// <summary>
        /// Additional non-public metadata attached to this listing.
        /// </summary>
        public IDictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Your unique identifier - Realo will throw an error when this value is already found for your account (maximum length 32 chars).
        /// </summary>
        public int? SourceId { get; set; }

        /// <summary>
        /// The main listingId of the project the listing belongs to.
        /// </summary>
        public int? ProjectId { get; set; }

    }

}
