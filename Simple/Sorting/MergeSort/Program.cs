
/*
                            { 5, 2, 6, 4, 8, 9, 7, 3, 1, 0, 5 }
                    { 5, 2, 6, 4, 8, 9 }              { 7, 3, 1, 0, 5 }
            { 5, 2, 6 }       { 4, 8, 9 }          { 7, 3, 1 }          { 0, 5 }
     { 5, 2 }     { 6 }      { 4, 8}     { 9 }           { 7, 3 }    { 1 }   { 0 }   { 5 }
{ 5 }   { 2 }     { 6 }   { 4 }     { 8 }   { 9 }     { 7 }   { 3 }     { 1 }   { 0 }     { 5 }

{ 2 , 5 }            { 4 , 6 }        { 8 , 9 }        { 3 ,  7 }        { 0 , 1 }    { 5 }
       { 2 , 4 , 5 , 6 }                       {3 ,  7,  8 , 9 }          { 0 , 1 , 5 }
            { 2 , 3 , 4 , 5 , 6 , 7, 8 , 9 }                 { 0 , 1 , 5 }
                {0 , 1 , 2 , 3 , 4 , 5 , 5 , 6 , 7, 8 , 9 }

*/


int[] array = new int[] { 5, 2, 6, 4, 8, 9, 7, 3, 1, 0, 5 };
printArray(MergeSort(array));

static int[] MergeSort(int[] array)
{
    MergeSortRec(array, 0, array.Length - 1);
    return array;
}

static void MergeSortRec(int[] array, int left, int right)
{
   if (left < right)
   {
    int middle = (left + right) / 2; 
    // Recursively sort both halves
    MergeSortRec(array, left, middle);
    MergeSortRec(array, middle + 1, right);

    // Merge the sorted halves
    Merge(array, left, right, middle);
   } 
   
}

static void Merge(int[] array, int left, int right, int middle)
{
   int n1 = middle - left +  1;
   int n2 = right - middle;

   int[] leftArray = new int[n1];
   int[] rightArray = new int[n2];

   for (int i = 0; i < n1; i++) leftArray[i] = array[left + i];
   for (int i = 0; i < n2; i++) rightArray[i] = array[middle + 1 + i];

   int iLeft = 0;
   int iRight = 0;
   int k = left;

   while (iLeft < n1 && iRight < n2)
   {
        if (leftArray[iLeft] <= rightArray[iRight])
            array[k++] = leftArray[iLeft++];
        else
            array[k++] = rightArray[iRight++];
   }

   while (iLeft < n1) array[k++] = leftArray[iLeft++]; 
   while (iRight < n2) array[k++] = rightArray[iRight++];

}


static void printArray(int[] array)
{
    foreach (int i in array)
        Console.Write(i + ", ");
    Console.WriteLine("");
}