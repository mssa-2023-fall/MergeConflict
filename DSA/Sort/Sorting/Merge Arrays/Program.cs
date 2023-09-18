//int[] ary1 = { 1, 3, 6, 8, 10, 32, 54, 64 };
//int[] ary2 = { 3, 6, 7, 23, 46, 86, 102, 112, 120 };

//int[] solutionAry = mergeArrays(ary1, ary2);

//Console.WriteLine(String.Join(",", solutionAry));



static int[] mergeArrays(int[] ary1, int[] ary2) {

    int[] solutionAry = new int[ary1.Length + ary2.Length];
    int ind1 = 0;
    int ind2 = 0;

    // iterate through each index in solutionAry
    for (int i = 0; i < solutionAry.Length; i++) {

        // if end of ary1 reached add rest of ary2 then leave loop
        if (ind1 >= ary1.Length) {
            while (ind2 < ary2.Length) { solutionAry[i++] = ary2[ind2++]; }
            break;
        }

        // if end of ary2 reached add rest of ary1 then leave loop
        if (ind2 >= ary2.Length) {
            while (ind1 < ary1.Length) { solutionAry[i++] = ary1[ind1++]; }
            break;
        }

        // compare and add the lowest number to the solutionAry
        solutionAry[i] = ary1[ind1] < ary2[ind2] ? ary1[ind1++] : ary2[ind2++];

    }

    return solutionAry;
}