# @param {Integer[]} nums
# @return {Integer}
def length_of_lis(nums)
  ans = [] # ans[i] means the longest increated subarray, which is ends with nums[i]
  result = 1
  nums.each_with_index do |item, i|
    temp = 1
    j = 0
    while j < i
      temp = [temp, ans[j] + 1].max if nums[j] < item
      j += 1
    end
    ans.push(temp)
    result = [temp, result].max
  end
  result
end

def run
  puts length_of_lis [10, 9, 2, 5, 3, 7, 101, 18] # 4
  puts length_of_lis [0, 1, 0, 3, 2, 3] # 4
  puts length_of_lis [7, 7, 7, 7, 7, 7, 7] # 1
  puts length_of_lis [1, 3, 6, 7, 9, 4, 10, 5, 6] # 6
end

run
