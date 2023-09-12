using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BinarySearch {
    public class BinarySearcher {

        // Methods
        public static int Search(int target, int[] array) {

            // if ary is empty return -1
            if (array.Length == 0) { return -1; }
            // if ary size is 1 compare target to ary[0] and return
            if (array.Length == 1) { return array[0] == target ? 0 : -1; }

            // Set Left Right and Mid
            int l = 0;
            int r = array.Length - 1;
            int mid = r / 2;

            // check if left or right are target
            if (array[l] == target) { return l; }
            if (array[r] == target) { return r; }
            // check if target is greater than right, less than left
            if (array[l] > target || array[r] < target) { return -1; }

            // create loop, while mid != left and mid != right
            while (mid != l && mid != r) {

                // assess whether mid is answer, if so return mid
                if (array[mid] == target) { return mid; }

                // if new mid < target move right
                // set left == mid
                // calculate new mid
                if (array[mid] < target) { 
                    l = mid;
                    mid += (r - l) / 2;
                }

                // if new mid > target move left
                // set right == mid
                // calculate new mid
                if (array[mid] > target) {
                    r = mid;
                    mid -= (r - l) / 2;
                }
            }

            // at end return -1
            return -1;
        }
    }
}
// Check that Array is at least size 2

// if ary is empty return -1
// if ary size is 1 compare target to ary[0] and return

// Set Left Right and Mid
// check if left or right are target
// if so return answer

// at this point we know ary is at least size 2 and starting points not answer 
// create loop, while mid != left and mid != right
// assess whether mid is answer, if so return mid
// if new mid < target move right
// set left == mid
// if new mid > target move left
// set right == mid

// calculate new mid

// at end return -1