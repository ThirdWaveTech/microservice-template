# Copy environment specific files to the config folder
$path = "Config\" + $OctopusParameters['Octopus.Environment.Name']
cd $path
cp *.* ..\

# Prepare for NServiceBus Deployment

# Get parameters from Octopus
$serviceName = $OctopusParameters['service.name']
$installDirectory = $OctopusActionPackageCustomInstallationDirectory

# Check to see if the service exists.
$service = Get-Service $serviceName -ErrorAction SilentlyContinue

if ($service) {
    Write-Host "An existing service => $($serviceName) was detected."

    Write-Host "Stopping and uninstalling the service => $($serviceName)"
    $fullPath = Resolve-Path "$installDirectory\NServiceBus.Host.exe"
    Stop-Service $serviceName -Force
      & "$fullPath" /uninstall /serviceName:"$serviceName" | Write-Host
}
