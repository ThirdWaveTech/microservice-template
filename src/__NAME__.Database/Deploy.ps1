.\Migrate.exe --configPath __NAME__.Database.dll.config `
	--connection "__NAME__" `
	--provider sqlserver2012 `
	--target "__NAME__.Database.dll" `
	--output --outputFilename migrate-output.sql --verbose=true `
	--task migrate `
	--timeout=600