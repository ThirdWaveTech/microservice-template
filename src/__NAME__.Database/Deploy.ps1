# Run the migrations against the target database
$dbServer = $OctopusParameters['db.server']
$dbName = $OctopusParameters['db.name']

.\Migrate.exe --connectionString "Server=$($dbServer);Database=$($dbName);Integrated Security=True" `
	--provider sqlserver2012 `
	--target "__NAME__.Database.dll" `
	--output --outputFilename migrate-output.sql --verbose=true `
	--task migrate `
	--timeout=600