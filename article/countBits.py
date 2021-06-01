#https://leetcode.com/problems/counting-bits/

class Solution(object):
    def countBits(self, num):
        """
        :type num: int
        :rtype: List[int]
        """
        if (num < 0):
            return []
       
        if (num == 0):
            return [0 ]
       
        result = [ 0, 1, 1, 2]
        if (num < len(result)):
            return result [:num + 1 ]
       
        lastNumber = 4
        i = lastNumber
        lastNumber = 4
        while (i < num + 1 ):
            if (i == lastNumber * 2):
                lastNumber = i
            result.append(result[i-lastNumber] + 1)
            i+= 1
        return result

if __name__ == "__main__":
    s = Solution()
    result = s.countBits( 20)
    for i in result:
        print(i)
    print ("done")
