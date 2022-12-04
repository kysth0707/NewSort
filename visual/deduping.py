import pygame
import random
import time

pygame.init()

ScreenWidth = 900
ScreenHeight = 600
screen = pygame.display.set_mode((ScreenWidth, ScreenHeight))
pygame.display.set_caption('Yo-yo Sort')

clock = pygame.time.Clock()
Run = True

Count = 30
OriginalList = [ random.randrange(1, 11) for _ in range(Count) ]
Dict = {}

Max, Min = max(OriginalList), min(OriginalList)

Doing = -1
OneBlock = ScreenWidth / Count
Yblock = 20

def DrawRect(i, Color, Value, Outline = 0):
	global screen, OneBlock
	pygame.draw.rect(screen, Color, [OneBlock * i, ScreenHeight - Value * Yblock,
											 OneBlock, Value * Yblock], Outline)

def DrawRect2(i, Color, Value, Outline = 0):
	global screen, OneBlock
	pygame.draw.rect(screen, Color, [OneBlock * i, 0,
											 OneBlock, Value * Yblock], Outline)

def DrawLine(y, Color, Outline = 3):
	pygame.draw.line(screen, Color, (0, ScreenHeight - y * Yblock), (ScreenWidth, ScreenHeight - y * Yblock), Outline)

def DrawLine2(y, Color, Outline = 3):
	pygame.draw.line(screen, Color, (0, y * Yblock), (ScreenWidth, y * Yblock), Outline)
screen.fill((255, 255, 255))
pygame.display.update()
time.sleep(5)
MyIndex = 0

while Run:
	screen.fill((255, 255, 255))

	for i in range(len(OriginalList)):
		DrawRect(i, (0, 0, 0), OriginalList[i])

	Index = 0
	for x in Dict.keys():
		for i in range(Dict[x]):
			DrawRect2(Index, (0, 0 ,0), x)
			Index += 1

	if Doing < 30 and Doing >= 0:
		DrawRect(Doing, (255, 0, 0), OriginalList[Doing])

		if Dict.get(OriginalList[Doing]) == None:
			Dict[OriginalList[Doing]] = 1
		else:
			Dict[OriginalList[Doing]] += 1
	elif Doing == 30 or Doing == 31:
		OriginalList = list(Dict.keys())
		for i, x in enumerate(OriginalList):
			DrawRect(i, (255, 0, 0), x)
	elif Doing == 32 or Doing == 33:
		OriginalList = sorted(OriginalList)
		for i, x in enumerate(OriginalList):
			DrawRect(i, (255, 0, 0), x)
	elif Doing == 34 or Doing == 34:
		for i in range(Count - len(OriginalList)):
			OriginalList.insert(0, 0)
	elif 35 <= Doing and Doing < max(Dict) + 35:
		OriginalList[Count - len(Dict) + (Doing - 35)] = 0
		try:
			for i in range(Dict.get(Doing - 34)):
				OriginalList[MyIndex] = Doing - 34
				DrawRect(MyIndex, (255, 0, 0), Doing - 34)
				MyIndex += 1
		except:
			pass

	Doing += 1

	pygame.display.update()

	for event in pygame.event.get():
		if event.type == pygame.QUIT:
			Run = False
			pygame.quit()

	clock.tick(5)