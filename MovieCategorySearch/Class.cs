


//public void ConfigureServices(IServiceCollection services)
//{
//    // Assume GetFeatureToggleValue() retrieves the current feature toggle setting
//    var useNewFeature = GetFeatureToggleValue("UseNewFeature");
//    // Dynamically register the appropriate implementation based on the feature toggle

//    if (useNewFeature)
//    {
//        services.AddScoped<IFeatureService, NewFeatureService>();
//    }
//    else
//    {
//        services.AddScoped<IFeatureService, StandardFeatureService>();
//    }
//    // Optional: You could combine this with the previous exampleto use the decorator pattern too! 
//    services.Decorate<IFeatureService, FeatureServiceProxy>();
//}

//private bool GetFeatureToggleValue(string featureName)
//{
//    // This method would typically check your 
//    // configuration source to determine if the feature is enabled 
//    // For simplicity, this is just a placeholder return false; 
//    // or true based on actual configuration
//}