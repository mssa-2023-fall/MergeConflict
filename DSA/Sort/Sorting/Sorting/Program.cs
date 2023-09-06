// SELECTION SORT

int[] arr = new int[5] { 85, 22, 63, 91, 24 };

int counter = arr.Length;

for (int i = 0; i < arr.Length; i++) {

    int max = 0;
    int indexOfMax = 0;
    // 1 - loop through all items in the array

    for (int j = 0; j < counter; j++) {
        int item = arr[j];
        //compare to next item. if new item > max, reassign max
        if (item > max) {
            max = item;
            indexOfMax = j;
        }
    }

    arr[indexOfMax] = arr[^(1+i)];
    arr[^(1+i)] = max;
    counter--;

}

foreach (var value in arr) { Console.Write($"| {value} |"); }