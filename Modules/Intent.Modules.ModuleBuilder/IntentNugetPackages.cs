﻿using Intent.Modules.Common.VisualStudio;

namespace Intent.Modules.ModuleBuilder
{
    public static class IntentNugetPackages
    {
        public static NugetPackageInfo IntentSdk = new("Intent.SoftwareFactory.SDK", "3.4.0-pre.0");

        public static NugetPackageInfo IntentPackager = new NugetPackageInfo("Intent.Packager", "3.4.0-pre.0")
            .SpecifyAssetsBehaviour(new[] { "all" }, new[] { "runtime", "build", "native", "contentfiles", "analyzers", "buildtransitive" });

        public static NugetPackageInfo IntentModulesCommon = new("Intent.Modules.Common", "3.3.16-pre.0");
        public static NugetPackageInfo IntentModulesCommonTypes = new("Intent.Modules.Common.Types", "3.3.6");
    }
}
