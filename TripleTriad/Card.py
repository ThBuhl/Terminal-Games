class Card:
    title:str
    n:str
    e:str
    s:str
    w:str

    def __init__(self, title:str, n:str, e:str, s:str, w:str):
        self.title = title
        self.n = n
        self.e = e
        self.s = s
        self.w = w
    
    def __str__(self):
        return f"{self.title}:\n {self.n}\n{self.w} {self.e}\n {self.s}"