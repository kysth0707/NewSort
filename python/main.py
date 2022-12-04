import random
import math
from timeit import default_timer
import sys
sys.setrecursionlimit(2147483647)

def YoyoSort(List):
	Min = min(List)
	Max = max(List)
	Dict = {}
	for x in List:
		if Dict.get(x) == None:
			Dict[x] = 1
		else:
			Dict[x] += 1
	
	New = []
	for x in range(Min, Max+1):
		if Dict.get(x) != None:
			New.extend([ x for _ in range(Dict[x]) ])
	return New

def QuickSort(List):
	if len(List) <= 1:
		return List
	Pivot = List[len(List) // 2]
	LesserList, EqualList, GreaterList = [], [], []
	for num in List:
		if num < Pivot:
			LesserList.append(num)
		elif num > Pivot:
			GreaterList.append(num)
		else:
			EqualList.append(num)
	return QuickSort(LesserList) + EqualList + QuickSort(GreaterList)

def CountingSort(Array):
	MaxValue = max(Array)
	CoutingArray = [0]*(MaxValue + 1)

	for i in Array:
		CoutingArray[i] += 1

	for i in range(MaxValue):
		CoutingArray[i+1] += CoutingArray[i]

	OutputArray = [-1]*len(Array)

	for i in Array:
		OutputArray[CoutingArray[i] -1] = i
		CoutingArray[i] -= 1
	return OutputArray

def DedupingSticker(List):
	Dict={}
	for x in List:
		if Dict.get(x) == None:
			Dict[x] = 1
		else:
			Dict[x] += 1
	List = list(Dict.keys())
	# List = QuickSort(List)
	# 아무 정렬이나 가능. 단, List 가 정렬되어야 함

	New = []
	for x in List:
		New.extend([ x for _ in range(Dict[x]) ])
	return New

def Run(From : int, To : int, N : int):
	"""
	From : 숫자 시작
	To : 숫자 도착 - 1
	N : 리스트 개수
	"""

	# OriginalList = [ random.randrange(From, To) for _ in range(N) ]
	# OriginalList = [ i + To for i in range(N) ]
	OriginalList = [ (N - i - 1 + To) for i in range(N) ]

	Start = default_timer()
	YoyoSort(OriginalList)
	print(f"Y {math.floor((default_timer() - Start)*1000)} ms")

	Start = default_timer()
	QuickSort(OriginalList)
	print(f"Q {math.floor((default_timer() - Start)*1000)} ms")

	Start = default_timer()
	CountingSort(OriginalList)
	print(f"C {math.floor((default_timer() - Start)*1000)} ms")

	Start = default_timer()
	DedupingSticker(OriginalList)
	print(f"D {math.floor((default_timer() - Start)*1000)} ms")


if __name__ == "__main__":
	Run(From=0, To=10000, N=1000000)