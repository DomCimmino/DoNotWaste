using System.Data;
using System.Data.SQLite;
using DoNotWaste.Models.DataModel;
using DoNotWaste.Repository.Interfaces;

namespace DoNotWaste.Repository;

public class BuildingRepository(IHouseHoldConnectionFactory factory)
    : BaseRepository(factory), IBuildingRepository
{
    public ResidentialBuilding GetResidential(NumberResidentialBuildings residentialNumber)
    {
        string query;
        DataTable dataTable;
        ResidentialBuilding residentialBuilding;
        switch (residentialNumber)
        {
            case NumberResidentialBuildings.First:
                query = $"""
                         SELECT
                             DE_KN_residential{(int)residentialNumber}_dishwasher,
                             DE_KN_residential{(int)residentialNumber}_freezer,
                             DE_KN_residential{(int)residentialNumber}_grid_import,
                             DE_KN_residential{(int)residentialNumber}_heat_pump,
                             DE_KN_residential{(int)residentialNumber}_pv,
                             DE_KN_residential{(int)residentialNumber}_washing_machine
                         FROM
                             household_data_60min_singleindex
                         WHERE
                             DE_KN_residential{(int)residentialNumber}_dishwasher IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_freezer IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_grid_import IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_heat_pump IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_pv IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_washing_machine IS NOT NULL AND
                             utc_timestamp BETWEEN '2016-05-01T00:00:00Z' AND '2017-05-01T00:00:00Z'
                         """;
                dataTable = DoQuery(query);
                residentialBuilding = new ResidentialBuilding()
                {
                    Id = (int)residentialNumber,
                    DishwasherConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_dishwasher"),
                    FreezerConsumption = LoadData(dataTable.Rows, $"DE_KN_residential{(int)residentialNumber}_freezer"),
                    UrbanImportElectricityGrid = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_grid_import"),
                    HeatPumpConsumption =
                        LoadData(dataTable.Rows, $"DE_KN_residential{(int)residentialNumber}_heat_pump"),
                    PhotovoltaicProduction = LoadData(dataTable.Rows, $"DE_KN_residential{(int)residentialNumber}_pv"),
                    WashingMachineConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_washing_machine")
                };
                break;
            case NumberResidentialBuildings.Second:
                query = $"""
                         SELECT
                             DE_KN_residential{(int)residentialNumber}_circulation_pump,
                             DE_KN_residential{(int)residentialNumber}_dishwasher,
                             DE_KN_residential{(int)residentialNumber}_freezer,
                             DE_KN_residential{(int)residentialNumber}_grid_import,
                             DE_KN_residential{(int)residentialNumber}_washing_machine
                         FROM
                             household_data_60min_singleindex
                         WHERE
                             DE_KN_residential{(int)residentialNumber}_circulation_pump IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_dishwasher IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_freezer IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_grid_import IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_washing_machine IS NOT NULL AND
                             utc_timestamp BETWEEN '2016-05-01T00:00:00Z' AND '2017-05-01T00:00:00Z'
                         """;
                dataTable = DoQuery(query);
                residentialBuilding = new ResidentialBuilding()
                {
                    Id = (int)residentialNumber,
                    CirculationPumpConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_circulation_pump"),
                    DishwasherConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_dishwasher"),
                    FreezerConsumption = LoadData(dataTable.Rows, $"DE_KN_residential{(int)residentialNumber}_freezer"),
                    UrbanImportElectricityGrid = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_grid_import"),
                    WashingMachineConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_washing_machine")
                };
                break;
            case NumberResidentialBuildings.Third:
                query = $"""
                         SELECT
                             DE_KN_residential{(int)residentialNumber}_circulation_pump,
                             DE_KN_residential{(int)residentialNumber}_dishwasher,
                             DE_KN_residential{(int)residentialNumber}_freezer,
                             DE_KN_residential{(int)residentialNumber}_grid_export,
                             DE_KN_residential{(int)residentialNumber}_grid_import,
                             DE_KN_residential{(int)residentialNumber}_pv,
                             DE_KN_residential{(int)residentialNumber}_refrigerator,
                             DE_KN_residential{(int)residentialNumber}_washing_machine
                         FROM
                             household_data_60min_singleindex
                         WHERE
                             DE_KN_residential{(int)residentialNumber}_circulation_pump IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_dishwasher IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_freezer IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_grid_export IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_grid_import IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_pv IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_refrigerator IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_washing_machine IS NOT NULL AND
                             utc_timestamp BETWEEN '2016-05-01T00:00:00Z' AND '2017-05-01T00:00:00Z'
                         """;
                dataTable = DoQuery(query);
                residentialBuilding = new ResidentialBuilding()
                {
                    Id = (int)residentialNumber,
                    CirculationPumpConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_circulation_pump"),
                    DishwasherConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_dishwasher"),
                    FreezerConsumption = LoadData(dataTable.Rows, $"DE_KN_residential{(int)residentialNumber}_freezer"),
                    UrbanExportElectricityGrid = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_grid_export"),
                    UrbanImportElectricityGrid = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_grid_import"),
                    PhotovoltaicProduction = LoadData(dataTable.Rows, $"DE_KN_residential{(int)residentialNumber}_pv"),
                    RefrigeratorConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_refrigerator"),
                    WashingMachineConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_washing_machine")
                };
                break;
            case NumberResidentialBuildings.Fourth:
                query = $"""
                         SELECT
                             DE_KN_residential{(int)residentialNumber}_dishwasher,
                             DE_KN_residential{(int)residentialNumber}_ev,
                             DE_KN_residential{(int)residentialNumber}_freezer,
                             DE_KN_residential{(int)residentialNumber}_grid_export,
                             DE_KN_residential{(int)residentialNumber}_grid_import,
                             DE_KN_residential{(int)residentialNumber}_heat_pump,
                             DE_KN_residential{(int)residentialNumber}_pv,
                             DE_KN_residential{(int)residentialNumber}_refrigerator,
                             DE_KN_residential{(int)residentialNumber}_washing_machine
                         FROM
                             household_data_60min_singleindex
                         WHERE
                             DE_KN_residential{(int)residentialNumber}_dishwasher IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_ev IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_freezer IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_grid_export IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_grid_import IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_heat_pump IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_pv IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_refrigerator IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_washing_machine IS NOT NULL AND
                             utc_timestamp BETWEEN '2016-05-01T00:00:00Z' AND '2017-05-01T00:00:00Z'
                         """;
                dataTable = DoQuery(query);
                residentialBuilding = new ResidentialBuilding()
                {
                    Id = (int)residentialNumber,
                    DishwasherConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_dishwasher"),
                    CharingEletricVehicleConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_ev"),
                    FreezerConsumption = LoadData(dataTable.Rows, $"DE_KN_residential{(int)residentialNumber}_freezer"),
                    UrbanExportElectricityGrid = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_grid_export"),
                    UrbanImportElectricityGrid = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_grid_import"),
                    HeatPumpConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_heat_pump"),
                    PhotovoltaicProduction = LoadData(dataTable.Rows, $"DE_KN_residential{(int)residentialNumber}_pv"),
                    RefrigeratorConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_refrigerator"),
                    WashingMachineConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_washing_machine")
                };
                break;
            case NumberResidentialBuildings.Fifth:
                query = $"""
                         SELECT
                             DE_KN_residential{(int)residentialNumber}_dishwasher,
                             DE_KN_residential{(int)residentialNumber}_grid_import,
                             DE_KN_residential{(int)residentialNumber}_refrigerator,
                             DE_KN_residential{(int)residentialNumber}_washing_machine
                         FROM
                             household_data_60min_singleindex
                         WHERE
                             DE_KN_residential{(int)residentialNumber}_dishwasher IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_grid_import IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_refrigerator IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_washing_machine IS NOT NULL AND
                             utc_timestamp BETWEEN '2016-05-01T00:00:00Z' AND '2017-05-01T00:00:00Z'
                         """;
                dataTable = DoQuery(query);
                residentialBuilding = new ResidentialBuilding()
                {
                    Id = (int)residentialNumber,
                    DishwasherConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_dishwasher"),
                    UrbanImportElectricityGrid = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_grid_import"),
                    RefrigeratorConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_refrigerator"),
                    WashingMachineConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_washing_machine")
                };
                break;
            case NumberResidentialBuildings.Sixth:
                query = $"""
                         SELECT
                             DE_KN_residential{(int)residentialNumber}_circulation_pump,
                             DE_KN_residential{(int)residentialNumber}_dishwasher,
                             DE_KN_residential{(int)residentialNumber}_freezer,
                             DE_KN_residential{(int)residentialNumber}_grid_export,
                             DE_KN_residential{(int)residentialNumber}_grid_import,
                             DE_KN_residential{(int)residentialNumber}_pv,
                             DE_KN_residential{(int)residentialNumber}_washing_machine
                         FROM
                             household_data_60min_singleindex
                         WHERE
                             DE_KN_residential{(int)residentialNumber}_circulation_pump IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_dishwasher IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_freezer IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_grid_export IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_grid_import IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_pv IS NOT NULL AND
                             DE_KN_residential{(int)residentialNumber}_washing_machine IS NOT NULL AND
                             utc_timestamp BETWEEN '2016-05-01T00:00:00Z' AND '2017-05-01T00:00:00Z'
                         """;
                dataTable = DoQuery(query);
                residentialBuilding = new ResidentialBuilding()
                {
                    Id = (int)residentialNumber,
                    CirculationPumpConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_circulation_pump"),
                    DishwasherConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_dishwasher"),
                    FreezerConsumption = LoadData(dataTable.Rows, $"DE_KN_residential{(int)residentialNumber}_freezer"),
                    UrbanExportElectricityGrid = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_grid_export"),
                    UrbanImportElectricityGrid = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_grid_import"),
                    PhotovoltaicProduction = LoadData(dataTable.Rows, $"DE_KN_residential{(int)residentialNumber}_pv"),
                    WashingMachineConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_washing_machine")
                };
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(residentialNumber), residentialNumber, null);
        }

        Connection.CloseAsync();
        return residentialBuilding;
    }

    public IndustrialBuilding GetIndustrial(NumberIndustrialBuildings industrialNumber)
    {
        string query;
        DataTable dataTable;
        IndustrialBuilding industrialBuilding;
        switch (industrialNumber)
        {
            case NumberIndustrialBuildings.First:
                query = $"""
                         SELECT
                             DE_KN_industrial{(int)industrialNumber}_grid_import,
                             DE_KN_industrial{(int)industrialNumber}_pv_1,
                             DE_KN_industrial{(int)industrialNumber}_pv_2
                         FROM
                             household_data_60min_singleindex
                         WHERE
                             DE_KN_industrial{(int)industrialNumber}_grid_import IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_pv_1 IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_pv_2 IS NOT NULL AND
                             utc_timestamp BETWEEN '2016-05-01T00:00:00Z' AND '2017-05-01T00:00:00Z'
                         """;
                dataTable = DoQuery(query);
                industrialBuilding = new IndustrialBuilding
                {
                    Id = (int)industrialNumber,
                    UrbanImportElectricityGrid = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_grid_import"),
                    FirstPhotovoltaicProduction = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_pv_1"),
                    SecondPhotovoltaicProduction = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_pv_2")
                };
                break;
            case NumberIndustrialBuildings.Second:
                query = $"""
                         SELECT
                             DE_KN_industrial{(int)industrialNumber}_grid_import,
                             DE_KN_industrial{(int)industrialNumber}_pv,
                             DE_KN_industrial{(int)industrialNumber}_storage_charge,
                             DE_KN_industrial{(int)industrialNumber}_storage_decharge
                         FROM
                             household_data_60min_singleindex
                         WHERE
                             DE_KN_industrial{(int)industrialNumber}_grid_import IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_pv IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_storage_charge IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_storage_decharge IS NOT NULL AND
                             utc_timestamp BETWEEN '2016-05-01T00:00:00Z' AND '2017-05-01T00:00:00Z'
                         """;
                dataTable = DoQuery(query);
                industrialBuilding = new IndustrialBuilding
                {
                    Id = (int)industrialNumber,
                    UrbanImportElectricityGrid = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_grid_import"),
                    FirstPhotovoltaicProduction = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_pv"),
                    StorageCharge = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_storage_charge"),
                    StorageDecharge = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_storage_decharge")
                };
                break;
            case NumberIndustrialBuildings.Third:
                query = $"""
                         SELECT
                             DE_KN_industrial{(int)industrialNumber}_area_offices,
                             DE_KN_industrial{(int)industrialNumber}_area_room_1,
                             DE_KN_industrial{(int)industrialNumber}_area_room_2,
                             DE_KN_industrial{(int)industrialNumber}_area_room_3,
                             DE_KN_industrial{(int)industrialNumber}_area_room_4,
                             DE_KN_industrial{(int)industrialNumber}_compressor,
                             DE_KN_industrial{(int)industrialNumber}_cooling_aggregate,
                             DE_KN_industrial{(int)industrialNumber}_cooling_pumps,
                             DE_KN_industrial{(int)industrialNumber}_dishwasher,
                             DE_KN_industrial{(int)industrialNumber}_ev,
                             DE_KN_industrial{(int)industrialNumber}_grid_import,
                             DE_KN_industrial{(int)industrialNumber}_machine_1,
                             DE_KN_industrial{(int)industrialNumber}_machine_2,
                             DE_KN_industrial{(int)industrialNumber}_machine_3,
                             DE_KN_industrial{(int)industrialNumber}_machine_4,
                             DE_KN_industrial{(int)industrialNumber}_machine_5,
                             DE_KN_industrial{(int)industrialNumber}_pv_facade,
                             DE_KN_industrial{(int)industrialNumber}_pv_roof,
                             DE_KN_industrial{(int)industrialNumber}_refrigerator,
                             DE_KN_industrial{(int)industrialNumber}_ventilation
                         FROM
                             household_data_60min_singleindex
                         WHERE
                             DE_KN_industrial{(int)industrialNumber}_area_offices IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_area_room_1 IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_area_room_2 IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_area_room_3 IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_area_room_4 IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_compressor IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_cooling_aggregate IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_cooling_pumps IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_dishwasher IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_ev IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_grid_import IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_machine_1 IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_machine_2 IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_machine_3 IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_machine_4 IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_machine_5 IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_pv_facade IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_pv_roof IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_refrigerator IS NOT NULL AND
                             DE_KN_industrial{(int)industrialNumber}_ventilation IS NOT NULL AND
                             utc_timestamp BETWEEN '2016-05-01T00:00:00Z' AND '2017-05-01T00:00:00Z'
                         """;
                dataTable = DoQuery(query);
                industrialBuilding = new IndustrialBuilding
                {
                    Id = (int)industrialNumber,
                    AreaOfficesConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_area_offices"),
                    FirstAreaRoomConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_area_room_1"),
                    SecondAreaRoomConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_area_room_2"),
                    ThirdAreaRoomConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_area_room_3"),
                    FourthAreaRoomConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_area_room_4"),
                    CompressorConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_compressor"),
                    CoolingAggregateConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_cooling_aggregate"),
                    CoolingPumpsConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_cooling_pumps"),
                    DishwasherConsumption = LoadData(dataTable.Rows,
                            $"DE_KN_industrial{(int)industrialNumber}_dishwasher"),
                    CharingEletricVehicleConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_ev"),
                    UrbanImportElectricityGrid = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_grid_import"),
                    FirstMachineConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_machine_1"),
                    SecondMachineConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_machine_2"),
                    ThirdMachineConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_machine_3"),
                    FourthMachineConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_machine_4"),
                    FacadePhotovoltaicProduction = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_pv_facade"),
                    RoofPhotovoltaicProduction = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_pv_roof"),
                    RefrigeratorConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_refrigerator"),
                    VentilationConsumption = LoadData(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_ventilation")
                };
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(industrialNumber), industrialNumber, null);
        }

        Connection.CloseAsync();
        return industrialBuilding;
    }
}