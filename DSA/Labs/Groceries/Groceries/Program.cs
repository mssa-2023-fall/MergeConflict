// declare items with prices

// initialize total price

// create a loop to scan items

// calculate total price using scanned items

// build stringbuilder

using System.Text;

double totalPrice = 0;
string? usersInput = null;
const byte ITEM_PRICE_INDEX = 0;
const byte ITEM_COUNT_INDEX = 1;

StringBuilder build = new();
Dictionary<string, List<double>> items = new() {
    { "apple", new() { 1.99d, 0 } },
    { "banana", new() { 2.49d, 0 } },
    { "orange", new() { 0.99d, 0 } },
    { "peach", new() { 1.29d, 0 } },
    { "watermelon", new() { 3.99d, 0 } }
};

while (usersInput != "done") {

    Console.WriteLine("\nPlease type the item you would like. Type 'done' if finished.");
    foreach (KeyValuePair<string, List<double>> item in items) {
        Console.WriteLine($"{item.Key} is ${item.Value[ITEM_PRICE_INDEX]}");
    }

    usersInput = Console.ReadLine();
    usersInput = usersInput.ToLower();

    if (usersInput == "done") {
        break;
    } else if (items.ContainsKey(usersInput)) {
        items[usersInput][ITEM_COUNT_INDEX] += 1;
        Console.WriteLine("Item added.");
    } else {
        Console.WriteLine("Item not found.");
    }
}

build.AppendLine("\n=======Receipt=======");

foreach (KeyValuePair<string, List<double>> item in items) {
    totalPrice += item.Value[ITEM_PRICE_INDEX] * item.Value[ITEM_COUNT_INDEX];
    build.AppendLine($"{item.Key}: {item.Value[ITEM_COUNT_INDEX]}");
}

build.AppendLine($"Total spent: ${totalPrice}");

Console.WriteLine(build);






// store item with price and scanned amount in hashmap
// store stringbuilder
// store users input