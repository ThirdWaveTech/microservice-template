$path = "App_Data\Config\" + $OctopusParameters['Octopus.Environment.Name']
cd $path
cp *.* ..\