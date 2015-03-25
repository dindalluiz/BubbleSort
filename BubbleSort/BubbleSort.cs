using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class BubbleSort
    {
        List<float> nums;

        public BubbleSort(List<float> n)
        {
            nums = n;
        }

        public void Sort()
        {
            for (int i = 0; i < nums.Count-1; i++)
            {
                for (int j = i+1; j < nums.Count; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        float aux = nums[i];
                        nums[i] = nums[j];
                        nums[j] = aux;
                    }
                }
            }

            /*for (int i=0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }*/
                   
        }

        public List<float> returnList()
        {
            return nums;
        }
    }
}
