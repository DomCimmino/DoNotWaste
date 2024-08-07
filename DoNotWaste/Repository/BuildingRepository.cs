using System.Data;
using System.Text.RegularExpressions;
using DoNotWaste.DTO;
using DoNotWaste.Models.DataModel;
using DoNotWaste.Repository.Interfaces;

namespace DoNotWaste.Repository;

public partial class BuildingRepository(IHouseHoldConnectionFactory factory)
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
                             utc_timestamp,
                             DE_KN_residential{(int)residentialNumber}_dishwasher,
                             DE_KN_residential{(int)residentialNumber}_freezer,
                             DE_KN_residential{(int)residentialNumber}_grid_import,
                             DE_KN_residential{(int)residentialNumber}_heat_pump,
                             DE_KN_residential{(int)residentialNumber}_pv,
                             DE_KN_residential{(int)residentialNumber}_washing_machine
                         FROM
                             household_data_60min_singleindex
                         WHERE
                             utc_timestamp BETWEEN '2016-01-01T00:00:00Z' AND '2017-06-01T00:00:00Z'
                         """;
                dataTable = DoQuery(query);
                residentialBuilding = new ResidentialBuilding()
                {
                    Id = (int)residentialNumber,
                    DishwasherConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_dishwasher"),
                    FreezerConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_freezer"),
                    UrbanImportElectricityGrid = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_grid_import"),
                    HeatPumpConsumption =
                        GetMonthlyConsumption(dataTable.Rows, $"DE_KN_residential{(int)residentialNumber}_heat_pump"),
                    PhotovoltaicProduction =
                        GetMonthlyConsumption(dataTable.Rows, $"DE_KN_residential{(int)residentialNumber}_pv"),
                    WashingMachineConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_washing_machine")
                };
                break;
            case NumberResidentialBuildings.Second:
                query = $"""
                         SELECT
                             utc_timestamp,
                             DE_KN_residential{(int)residentialNumber}_circulation_pump,
                             DE_KN_residential{(int)residentialNumber}_dishwasher,
                             DE_KN_residential{(int)residentialNumber}_freezer,
                             DE_KN_residential{(int)residentialNumber}_grid_import,
                             DE_KN_residential{(int)residentialNumber}_washing_machine
                         FROM
                             household_data_60min_singleindex
                         WHERE
                             utc_timestamp BETWEEN '2016-01-01T00:00:00Z' AND '2017-06-01T00:00:00Z'
                         """;
                dataTable = DoQuery(query);
                residentialBuilding = new ResidentialBuilding()
                {
                    Id = (int)residentialNumber,
                    CirculationPumpConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_circulation_pump"),
                    DishwasherConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_dishwasher"),
                    FreezerConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_freezer"),
                    UrbanImportElectricityGrid = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_grid_import"),
                    WashingMachineConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_washing_machine")
                };
                break;
            case NumberResidentialBuildings.Third:
                query = $"""
                         SELECT
                             utc_timestamp,
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
                             utc_timestamp BETWEEN '2016-01-01T00:00:00Z' AND '2017-06-01T00:00:00Z'
                         """;
                dataTable = DoQuery(query);
                residentialBuilding = new ResidentialBuilding()
                {
                    Id = (int)residentialNumber,
                    CirculationPumpConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_circulation_pump"),
                    DishwasherConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_dishwasher"),
                    FreezerConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_freezer"),
                    UrbanExportElectricityGrid = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_grid_export"),
                    UrbanImportElectricityGrid = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_grid_import"),
                    PhotovoltaicProduction =
                        GetMonthlyConsumption(dataTable.Rows, $"DE_KN_residential{(int)residentialNumber}_pv"),
                    RefrigeratorConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_refrigerator"),
                    WashingMachineConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_washing_machine")
                };
                break;
            case NumberResidentialBuildings.Fourth:
                query = $"""
                         SELECT
                             utc_timestamp,
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
                             utc_timestamp BETWEEN '2016-01-01T00:00:00Z' AND '2017-06-01T00:00:00Z'
                         """;
                dataTable = DoQuery(query);
                residentialBuilding = new ResidentialBuilding()
                {
                    Id = (int)residentialNumber,
                    DishwasherConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_dishwasher"),
                    CharingEletricVehicleConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_ev"),
                    FreezerConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_freezer"),
                    UrbanExportElectricityGrid = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_grid_export"),
                    UrbanImportElectricityGrid = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_grid_import"),
                    HeatPumpConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_heat_pump"),
                    PhotovoltaicProduction =
                        GetMonthlyConsumption(dataTable.Rows, $"DE_KN_residential{(int)residentialNumber}_pv"),
                    RefrigeratorConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_refrigerator"),
                    WashingMachineConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_washing_machine")
                };
                break;
            case NumberResidentialBuildings.Fifth:
                query = $"""
                         SELECT
                             utc_timestamp,
                             DE_KN_residential{(int)residentialNumber}_dishwasher,
                             DE_KN_residential{(int)residentialNumber}_grid_import,
                             DE_KN_residential{(int)residentialNumber}_refrigerator,
                             DE_KN_residential{(int)residentialNumber}_washing_machine
                         FROM
                             household_data_60min_singleindex
                         WHERE
                             utc_timestamp BETWEEN '2016-01-01T00:00:00Z' AND '2017-06-01T00:00:00Z'
                         """;
                dataTable = DoQuery(query);
                residentialBuilding = new ResidentialBuilding()
                {
                    Id = (int)residentialNumber,
                    DishwasherConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_dishwasher"),
                    UrbanImportElectricityGrid = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_grid_import"),
                    RefrigeratorConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_refrigerator"),
                    WashingMachineConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_washing_machine")
                };
                break;
            case NumberResidentialBuildings.Sixth:
                query = $"""
                         SELECT
                             utc_timestamp,
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
                             utc_timestamp BETWEEN '2016-01-01T00:00:00Z' AND '2017-06-01T00:00:00Z'
                         """;
                dataTable = DoQuery(query);
                residentialBuilding = new ResidentialBuilding()
                {
                    Id = (int)residentialNumber,
                    CirculationPumpConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_circulation_pump"),
                    DishwasherConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_dishwasher"),
                    FreezerConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_freezer"),
                    UrbanExportElectricityGrid = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_grid_export"),
                    UrbanImportElectricityGrid = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_grid_import"),
                    PhotovoltaicProduction =
                        GetMonthlyConsumption(dataTable.Rows, $"DE_KN_residential{(int)residentialNumber}_pv"),
                    WashingMachineConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_residential{(int)residentialNumber}_washing_machine")
                };
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(residentialNumber), residentialNumber, null);
        }

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
                             utc_timestamp,
                             DE_KN_industrial{(int)industrialNumber}_grid_import,
                             DE_KN_industrial{(int)industrialNumber}_pv_1,
                             DE_KN_industrial{(int)industrialNumber}_pv_2
                         FROM
                             household_data_60min_singleindex
                         WHERE
                             utc_timestamp BETWEEN '2016-01-01T00:00:00Z' AND '2017-06-01T00:00:00Z'
                         """;
                dataTable = DoQuery(query);
                industrialBuilding = new IndustrialBuilding
                {
                    Id = (int)industrialNumber,
                    UrbanImportElectricityGrid = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_grid_import"),
                    FirstPhotovoltaicProduction = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_pv_1"),
                    SecondPhotovoltaicProduction = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_pv_2")
                };
                break;
            case NumberIndustrialBuildings.Second:
                query = $"""
                         SELECT
                             utc_timestamp,
                             DE_KN_industrial{(int)industrialNumber}_grid_import,
                             DE_KN_industrial{(int)industrialNumber}_pv,
                             DE_KN_industrial{(int)industrialNumber}_storage_charge,
                             DE_KN_industrial{(int)industrialNumber}_storage_decharge
                         FROM
                             household_data_60min_singleindex
                         WHERE
                             utc_timestamp BETWEEN '2016-01-01T00:00:00Z' AND '2017-06-01T00:00:00Z'
                         """;
                dataTable = DoQuery(query);
                industrialBuilding = new IndustrialBuilding
                {
                    Id = (int)industrialNumber,
                    UrbanImportElectricityGrid = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_grid_import"),
                    FirstPhotovoltaicProduction = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_pv"),
                    StorageCharge = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_storage_charge"),
                    StorageDecharge = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_storage_decharge")
                };
                break;
            case NumberIndustrialBuildings.Third:
                query = $"""
                         SELECT
                             utc_timestamp,
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
                             utc_timestamp BETWEEN '2016-01-01T00:00:00Z' AND '2017-06-01T00:00:00Z'
                         """;
                dataTable = DoQuery(query);
                industrialBuilding = new IndustrialBuilding
                {
                    Id = (int)industrialNumber,
                    AreaOfficesConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_area_offices"),
                    FirstAreaRoomConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_area_room_1"),
                    SecondAreaRoomConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_area_room_2"),
                    ThirdAreaRoomConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_area_room_3"),
                    FourthAreaRoomConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_area_room_4"),
                    CompressorConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_compressor"),
                    CoolingAggregateConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_cooling_aggregate"),
                    CoolingPumpsConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_cooling_pumps"),
                    DishwasherConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_dishwasher"),
                    CharingEletricVehicleConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_ev"),
                    UrbanImportElectricityGrid = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_grid_import"),
                    FirstMachineConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_machine_1"),
                    SecondMachineConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_machine_2"),
                    ThirdMachineConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_machine_3"),
                    FourthMachineConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_machine_4"),
                    FacadePhotovoltaicProduction = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_pv_facade"),
                    RoofPhotovoltaicProduction = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_pv_roof"),
                    RefrigeratorConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_refrigerator"),
                    VentilationConsumption = GetMonthlyConsumption(dataTable.Rows,
                        $"DE_KN_industrial{(int)industrialNumber}_ventilation")
                };
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(industrialNumber), industrialNumber, null);
        }

        return industrialBuilding;
    }

    public List<DeviceRecordDto> GetSingleBuildingDevicesConsumptions<T>(T building) where T : BaseBuilding
    {
        var deviceConsumptions = new List<DeviceRecordDto>();
        var properties = typeof(T).GetProperties();

        foreach (var property in properties)
        {
            if (property.Name.Contains("Production") || property.Name.Contains("Export") ||
                property.Name.Contains("Import")) continue;
            if (property.GetValue(building) is not List<Record> records) continue;
            var totalConsumption = records
                .Where(record => record.Value.HasValue)
                .Sum(record => record.Value ?? 0);

            deviceConsumptions.Add(new DeviceRecordDto
            {
                DeviceName = ConvertToReadableName(property.Name),
                Value = totalConsumption
            });
        }

        return deviceConsumptions;
    }

    public List<DeviceRecordDto> CalculateDeviceConsumptionsForAllBuildings(bool isResidential = true,
        bool isAverage = true)
    {
        var totalConsumptions = new Dictionary<string, double>();
        var deviceCount = new Dictionary<string, int>();

        if (isResidential)
        {
            foreach (NumberResidentialBuildings residentialNumber in Enum.GetValues(typeof(NumberResidentialBuildings)))
            {
                var building = GetResidential(residentialNumber);

                var properties = typeof(ResidentialBuilding).GetProperties();

                foreach (var property in properties)
                {
                    if (!property.Name.Contains("Consumption")) continue;
                    
                    if (property.GetValue(building) is not List<Record> records) continue;

                    foreach (var record in records)
                    {
                        if (!record.Value.HasValue) continue;

                        var deviceName = ConvertToReadableName(property.Name);

                        if (!totalConsumptions.ContainsKey(deviceName))
                        {
                            totalConsumptions[deviceName] = 0;
                            deviceCount[deviceName] = 0;
                        }

                        totalConsumptions[deviceName] += record.Value.Value;
                        deviceCount[deviceName]++;
                    }
                }
            }
        }
        else
        {
            foreach (NumberIndustrialBuildings industrialBuildings in Enum.GetValues(typeof(NumberIndustrialBuildings)))
            {
                var building = GetIndustrial(industrialBuildings);

                var properties = typeof(IndustrialBuilding).GetProperties();

                foreach (var property in properties)
                {
                    if (!property.Name.Contains("Consumption")) continue;
                    
                    if (property.GetValue(building) is not List<Record> records) continue;

                    foreach (var record in records)
                    {
                        if (!record.Value.HasValue) continue;

                        var deviceName = ConvertToReadableName(property.Name);

                        if (!totalConsumptions.ContainsKey(deviceName))
                        {
                            totalConsumptions[deviceName] = 0;
                            deviceCount[deviceName] = 0;
                        }

                        totalConsumptions[deviceName] += record.Value.Value;
                        deviceCount[deviceName]++;
                    }
                }
            }
        }

        if (isAverage)
        {
            return (from deviceName in totalConsumptions.Keys
                let averageConsumption = totalConsumptions[deviceName] / deviceCount[deviceName]
                select new DeviceRecordDto { DeviceName = deviceName, Value = averageConsumption }).ToList();
        }

        return (from deviceName in totalConsumptions.Keys
                select new DeviceRecordDto
                    { DeviceName = deviceName, Value = totalConsumptions[deviceName] })
            .ToList();
    }

    public IEnumerable<DeviceRecordDto> GetSingleBuildingPhotovoltaicProduction<T>(T building) where T : BaseBuilding
    {
        var deviceConsumptions = new List<DeviceRecordDto>();
        var properties = typeof(T).GetProperties();

        foreach (var property in properties)
        {
            if (!property.Name.Contains("Photovoltaic")) continue;
            if (property.GetValue(building) is not List<Record> records) continue;
            var totalConsumption = records
                .Where(record => record.Value.HasValue)
                .Sum(record => record.Value ?? 0);

            deviceConsumptions.Add(new DeviceRecordDto
            {
                DeviceName = ConvertToReadableName(property.Name),
                Value = totalConsumption
            });
        }

        return deviceConsumptions;
    }
    
    public IEnumerable<DeviceRecordDto> GetSingleBuildingGridImport<T>(T building) where T : BaseBuilding
    {
        var deviceConsumptions = new List<DeviceRecordDto>();
        var properties = typeof(T).GetProperties();

        foreach (var property in properties)
        {
            if (!property.Name.Contains("Import")) continue;
            if (property.GetValue(building) is not List<Record> records) continue;
            var totalConsumption = records
                .Where(record => record.Value.HasValue)
                .Sum(record => record.Value ?? 0);

            deviceConsumptions.Add(new DeviceRecordDto
            {
                DeviceName = ConvertToReadableName(property.Name),
                Value = totalConsumption
            });
        }

        return deviceConsumptions;
    }
    
    public IEnumerable<DeviceRecordDto> GetBuildingTypePhotovoltaicProduction(bool isResidential = true) 
    {
        var totalConsumptions = new Dictionary<string, double>();
        var deviceCount = new Dictionary<string, int>();

        if (isResidential)
        {
            foreach (NumberResidentialBuildings residentialNumber in Enum.GetValues(typeof(NumberResidentialBuildings)))
            {
                var building = GetResidential(residentialNumber);

                var properties = typeof(ResidentialBuilding).GetProperties();

                foreach (var property in properties)
                {
                    if (!property.Name.Contains("Photovoltaic")) continue;
                    
                    if (property.GetValue(building) is not List<Record> records) continue;

                    foreach (var record in records)
                    {
                        if (!record.Value.HasValue) continue;

                        var deviceName = ConvertToReadableName(property.Name);

                        if (!totalConsumptions.ContainsKey(deviceName))
                        {
                            totalConsumptions[deviceName] = 0;
                            deviceCount[deviceName] = 0;
                        }

                        totalConsumptions[deviceName] += record.Value.Value;
                        deviceCount[deviceName]++;
                    }
                }
            }
        }
        else
        {
            foreach (NumberIndustrialBuildings industrialBuildings in Enum.GetValues(typeof(NumberIndustrialBuildings)))
            {
                var building = GetIndustrial(industrialBuildings);

                var properties = typeof(IndustrialBuilding).GetProperties();

                foreach (var property in properties)
                {
                    if (!property.Name.Contains("Photovoltaic")) continue;
                    
                    if (property.GetValue(building) is not List<Record> records) continue;

                    foreach (var record in records)
                    {
                        if (!record.Value.HasValue) continue;

                        var deviceName = ConvertToReadableName(property.Name);

                        if (!totalConsumptions.ContainsKey(deviceName))
                        {
                            totalConsumptions[deviceName] = 0;
                            deviceCount[deviceName] = 0;
                        }

                        totalConsumptions[deviceName] += record.Value.Value;
                        deviceCount[deviceName]++;
                    }
                }
            }
        }
        
        return (from deviceName in totalConsumptions.Keys
                select new DeviceRecordDto
                    { DeviceName = deviceName, Value = totalConsumptions[deviceName] })
            .ToList();
    }

    public IEnumerable<DeviceRecordDto> GetBuildingTypeImportGrid(bool isResidential = true) 
    {
        var totalConsumptions = new Dictionary<string, double>();
        var deviceCount = new Dictionary<string, int>();

        if (isResidential)
        {
            foreach (NumberResidentialBuildings residentialNumber in Enum.GetValues(typeof(NumberResidentialBuildings)))
            {
                var building = GetResidential(residentialNumber);

                var properties = typeof(ResidentialBuilding).GetProperties();

                foreach (var property in properties)
                {
                    if (!property.Name.Contains("Import")) continue;
                    
                    if (property.GetValue(building) is not List<Record> records) continue;

                    foreach (var record in records)
                    {
                        if (!record.Value.HasValue) continue;

                        var deviceName = ConvertToReadableName(property.Name);

                        if (!totalConsumptions.ContainsKey(deviceName))
                        {
                            totalConsumptions[deviceName] = 0;
                            deviceCount[deviceName] = 0;
                        }

                        totalConsumptions[deviceName] += record.Value.Value;
                        deviceCount[deviceName]++;
                    }
                }
            }
        }
        else
        {
            foreach (NumberIndustrialBuildings industrialBuildings in Enum.GetValues(typeof(NumberIndustrialBuildings)))
            {
                var building = GetIndustrial(industrialBuildings);

                var properties = typeof(IndustrialBuilding).GetProperties();

                foreach (var property in properties)
                {
                    if (!property.Name.Contains("Import")) continue;
                    
                    if (property.GetValue(building) is not List<Record> records) continue;

                    foreach (var record in records)
                    {
                        if (!record.Value.HasValue) continue;

                        var deviceName = ConvertToReadableName(property.Name);

                        if (!totalConsumptions.ContainsKey(deviceName))
                        {
                            totalConsumptions[deviceName] = 0;
                            deviceCount[deviceName] = 0;
                        }

                        totalConsumptions[deviceName] += record.Value.Value;
                        deviceCount[deviceName]++;
                    }
                }
            }
        }
        
        return (from deviceName in totalConsumptions.Keys
                select new DeviceRecordDto
                    { DeviceName = deviceName, Value = totalConsumptions[deviceName] })
            .ToList();
    }
        
    private static string ConvertToReadableName(string propertyName)
    {
        var readableName = propertyName.Replace("Consumption", "");
        return MyRegex().Replace(readableName, "$1 $2");
    }

    [GeneratedRegex("([a-z])([A-Z])")]
    private static partial Regex MyRegex();
}