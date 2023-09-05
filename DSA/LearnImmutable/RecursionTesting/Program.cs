string startDirectory = args[0];

PrintDir(startDirectory);

static void PrintDir(string startDirectory) {

    var allDir = Directory.EnumerateDirectories(startDirectory);

    foreach (var directory in allDir) {
        try {
            Console.WriteLine($"Accessed directory: {directory}");
            PrintDir(directory);
        } catch (UnauthorizedAccessException) {
            Console.WriteLine($"Cannot access: {directory}");
        }
    }

}



/*
foreach (var file in allFiles) {

    try {
        DirectoryInfo directoryInfo = new DirectoryInfo(file);
        Console.WriteLine($"Accessed directory: {directoryInfo.FullName}");


        foreach (var file2 in Directory.EnumerateDirectories(file)) {

            try {
                DirectoryInfo directoryInfo2 = new DirectoryInfo(file2);
                Console.WriteLine($"Accessed directory: {directoryInfo2.FullName}");
            } catch (UnauthorizedAccessException) {
                Console.WriteLine($"Cannot access: {file2}");
                continue;
            }

        }



    } catch (UnauthorizedAccessException) { 
        Console.WriteLine($"Cannot access: {file}");
        continue;
    }



    
}
*/
