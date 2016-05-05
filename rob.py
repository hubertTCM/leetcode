#https://leetcode.com/problems/house-robber-iii/

#Definition for a binary tree node.
class TreeNode(object):
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution(object):
    def rob(self, root):
        """
        :type root: TreeNode
        :rtype: int
        """
        
        return self.robChild(root, True)
     
    def robChild(self, root, canSelectRoot): #Time Limit Exceeded
        if (root == None):
            return 0
        
        if (canSelectRoot):
            selectRoot = root.val + self.robChild(root.left, False) +  self.robChild(root.right, False)
            unSelectRoot = self.robChild(root.left, True) + self.robChild(root.right, True)
            
            if (selectRoot > unSelectRoot):
                return selectRoot
            return unSelectRoot
        
        return self.robChild(root.left, True) +  self.robChild(root.right, True)

if __name__ == "__main__": 
    root = TreeNode(4)
    root.left = TreeNode(1)
    root.left.right = TreeNode(2)
    root.left.right.right = TreeNode(3)
    s = Solution()
    result = s.rob(root)
    print (str(result) + ": done")
