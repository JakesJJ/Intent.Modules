﻿using Intent.Modules.Common.VisualStudio;

namespace Intent.Modules.ModuleBuilder
{
    public static class NugetPackages
    {
        public static NugetPackageInfo IntentPackager = new NugetPackageInfo("Intent.Packager", "3.0.*")
            .SpecifyAssetsBehaviour(new[] { "all" }, new[] { "runtime", "build", "native", "contentfiles", "analyzers", "buildtransitive" });
        public static NugetPackageInfo IntentSdk = new NugetPackageInfo("Intent.SoftwareFactory.SDK", "3.0.*");
        public static NugetPackageInfo IntentModulesCommon = new NugetPackageInfo("Intent.Modules.Common", "3.0.*");
        public static NugetPackageInfo IntentModulesCommonTypes = new NugetPackageInfo("Intent.Modules.Common.Types", "3.0.*");
    }
}
