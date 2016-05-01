# https://leetcode.com/problems/power-of-four/

class Solution(object):
    def isPowerOfFour(self, num):
        """
        :type num: int
        :rtype: bool
        """
        if (num == 0):
            return False
        currentNumber = num
        while(True):
            if (currentNumber == 1):
                return True
            
            if (currentNumber % 4 != 0):
                return False
            currentNumber = currentNumber / 4

        return True

if __name__ == "__main__": 
    s = Solution()
    for i in range(1, 100):
        result = s.isPowerOfFour(i)
        print(str(i) + ": " + str(result))
    print ("done")
