''' Done
给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。

你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。

示例:

给定 nums = [2, 7, 11, 15], target = 9

因为 nums[0] + nums[1] = 2 + 7 = 9
所以返回 [0, 1]
'''
class Solution(object):
    def twoSum(self, nums, target):
        """
        :type nums: List[int]
        :type target: int
        :rtype: List[int]
        """
        dic = {}
        for i, x in enumerate(nums):
            if target - x in dic:
                return [dic[target - x], i]
            dic[x] = i


if __name__ == '__main__':
    s = Solution()
    nums = [
        230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887,
        755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221,
        847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794,
        587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306,
        506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546,
        60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430,
        803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789
    ]
    ret = s.twoSum(nums, 542)
    print(ret)


