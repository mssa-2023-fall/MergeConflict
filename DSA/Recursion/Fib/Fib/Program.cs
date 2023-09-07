// fibonacci
// fib of a number = sum of fib of previous 2 numbers
// fib 0 = 0 fib 1 = 1

// recurse through until 0 and add that number to previous fib number
Dictionary<int, int> computedValues = new();
//Console.WriteLine(fibDance(8));

foreach (var item in fibDance2(100)) {
    if (item <= 0) break;
    Console.WriteLine(item);
}

int fibDance(int num) {
    if (num == 0) { return 0; }
    if (num == 1) { return 1; }

    int num1 = num - 1;
    int num2 = num - 2;
    int fibNum1 = 0;
    int fibNum2 = 0;

    if (computedValues.ContainsKey(num1)) {
        fibNum1 = computedValues[num1];
    } else {
        fibNum1 = fibDance(num1);
        computedValues.Add(num1, fibNum1);
    }

    if (computedValues.ContainsKey(num2)) {
        fibNum2 = computedValues[num2];
    } else {
        fibNum2 = fibDance(num2);
        computedValues.Add(num2, fibNum2);
    }

    return fibNum1 + fibNum2;
}


// iterative
// iterate up to given num
// fib num = curr + prev?
static IEnumerable<int> fibDance2(int target) {
    int fibNum = 1;
    int currFib = 1;
    int prevFib = 0;
    
    for (int i = 1; i < target; i++) {
        fibNum = currFib + prevFib;
        yield return fibNum;
        prevFib = currFib;
        currFib = fibNum;
    }

 //   return fibNum;

}