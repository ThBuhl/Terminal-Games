import Card

class Board:
    board:list

    def __init__(self):
        self.board = [[Space(),Space(),Space()],[Space(),Space(),Space()],[Space(),Space(),Space()]]
    
    def __str__(self):
        emptySpace = " "
        retStr = "   1   2   3  \n"
        for row in self.board:
            top = " "
            mid = f"{self.board.index(row)+1}"
            bot = " "
            for space in row:
                top += f"| {space.card.n if space.card != None else emptySpace} "
                mid += f"|{space.card.w if space.card != None else emptySpace} {space.card.e if space.card != None else emptySpace}"
                bot += f"| {space.card.s if space.card != None else emptySpace} "
            retStr += "  --- --- --- \n"
            retStr += (top + "|\n" + mid + "|\n" + bot + "|\n")
        retStr += "  --- --- --- "
        return retStr
    
    def placeCard(self, card:Card, x:int, y:int):
        self.board[y-1][x-1].card = card    

class Space:
    card:Card
    color:str

    def __init__(self):
        self.card = None
        self.color = None

#Contains a 3x3 board
# Each spot can be either red, blue, or uncolored
# Contains logic for playing a card, and having it battle neighboring cards
# Also contains a list of active rules, that affect the kind of battling going on, and such

#List of rules:
#   Reverse
#   Fallen Ace
#   Plus
#   Same