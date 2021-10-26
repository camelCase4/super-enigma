"""
Author: Roger Jay Sering | BSIT-3C
Date: 10/17/2021
Title: (Midterm) A simple game in free el 1
"""
import random
import time
class theElementals:
    def __init__(self,name,gamemode,playerElement):
        self.name = name
        self.gamemode = gamemode
        self.playerElement = playerElement.upper()
        self.computerElement = self.comp_element()
        self.playerWins = 0
        self.computerWins = 0
        self.playerHealth = self.health()
        self.computerHealth = self.health()
        self.spamCheckerForComputer = ""
        self.spamCheckerForPlayer = ""
        self.computerSkillPool = self.comp_skill_pool()
        self.quit = False
        self.skills ={
            "FIRE":{
                "Dragon Breathe":200,
                "Dragon Scale":300, #heal
                "Dragon Aura":300,
                "Dragon tail":400,
                "Sun Burst":500
            },
            "LIGHTNING":{
                "Chidori Strike":200,
                "Lightning Evade": self.lightning_evade(),
                "Lightning Burst": self.lightning_burst(),
                "Thunder Shock":400,
                "Lightning Bolt":500
            },
            "EARTH":{
                "Toss":400,
                "Avalanche":400,
                "Echo Slam":400,
                "Earth Splitter":400,
                "Earth Shock":500
            }
        }
    def lightning_burst(self):
        result = random.randint(1,100)
        return 1000 if result >= 95 else 200

    def lightning_evade(self):
        result = random.randint(1,100)
        return 200 if result >= 50 else 500
    def comp_element(self):
        num = random.randint(1,3)
        if num == 1:
            return "FIRE"
        elif num == 2:
            return "LIGHTNING"
        else:
            return "EARTH"
    def health(self):
        if self.gamemode == 1:
            return 1000
        elif self.gamemode == 2:
            return 1500
        else:
            return 2000
    def comp_skill_pool(self):
        if self.gamemode == 1:
            return 3
        elif self.gamemode == 2:
            return 4
        else:
            return 5

    def timer_for_dramatics(self):
        t = 3
        while True:
            print(t)
            time.sleep(1)
            t -= 1
            if t == 0:
                break
    def stopgame(self):
        return True if self.quit == True else False

    def computerMove(self):
        if self.computerHealth <= 0:
            self.playerWins += 1
            print("You successfully defeated computer!")
            print("Your Wins: {} || Computer Wins: {}".format(self.playerWins,self.computerWins))
            anothermatch = input("Do you want to request a rematch? [Y]es or [N]o?").upper()
            if anothermatch == "Y":
                self.spamCheckerForPlayer = ""
                self.spamCheckerForComputer = ""
                self.playerHealth = self.health()
                self.computerHealth = self.health()
                print("Prepare and good luck magi!")
            else:
                print("Rest well magi.")
                self.quit = True

        else:
            self.quit = False
            print("Computer is attacking!")
            self.timer_for_dramatics()
            counter = 0
            while True:
                skillattack = random.randint(0,self.computerSkillPool-1)
                for i in range(self.computerSkillPool):
                    if str(i) in self.spamCheckerForComputer:
                        counter+=1
                    if counter == self.computerSkillPool:
                        self.spamCheckerForComputer = ""
                        #self.spamCheckerForPlayer = ""
                        counter = 0
                    if counter == 3 and self.computerSkillPool > 3:
                        self.spamCheckerForPlayer = ""

                if str(skillattack) in self.spamCheckerForComputer:
                    counter = 0
                    continue

                else:
                    self.spamCheckerForComputer+=str(skillattack)
                    break


            skillnametothrow = list(self.skills.get(self.computerElement))[skillattack]
            skilldamagetothrow = self.skills.get(self.computerElement).get(list(self.skills.get(self.computerElement))[skillattack])

            if skillnametothrow != "Dragon Scale":
                print("Computer casted {} on you! you receive {} damage!".format(skillnametothrow, skilldamagetothrow))
                print("Your health = {} || Computer health = {}".format((self.playerHealth-skilldamagetothrow),self.computerHealth))
                self.playerHealth -= skilldamagetothrow
            else:
                print("Computer used dragon scale! healed by 300 hp!")
                print("Your health = {} || Computer health = {}".format(self.playerHealth,(self.computerHealth+skilldamagetothrow)))
                self.computerHealth += skilldamagetothrow

    def playerMove(self):
        if self.playerHealth <= 0:
            self.computerWins +=1
            print("You died!")
            print("Your Wins: {} || Computer Wins: {}".format(self.playerWins, self.computerWins))
            rematch = input("Do you want to request a rematch? [Y]es or [N]o?").upper()
            if rematch == "Y":
                self.spamCheckerForPlayer = ""
                self.spamCheckerForComputer = ""
                self.playerHealth = self.health()
                self.computerHealth = self.health()
                print("Prepare and good luck magi!")
            else:
                print("Rest well magi. Do better next time.")
                self.quit = True

        else:
            self.quit = False
            print("Your move!")
            checker,flag = 0,0
            for i in range(3):
                if str(i) in self.spamCheckerForPlayer:
                    checker += 1
                    if checker == 3 and self.computerSkillPool > 3:
                        print("All of your skills are on cooldown! Resort to hand to hand combat!")
                        #self.spamCheckerForPlayer = ""
                        flag = 1
                        break
                    elif checker == 3 and self.computerSkillPool == 3:
                        self.spamCheckerForPlayer = ""
                        for x in range(3):
                            print("[{}] -> Skill Name: {} Damage: {}".format(x,list(self.skills.get(self.playerElement))[x],self.skills.get(self.playerElement).get(list(self.skills.get(self.playerElement))[x])))


                else:
                    print("[{}] -> Skill Name: {} Damage: {}".format(i,list(self.skills.get(self.playerElement))[i],self.skills.get(self.playerElement).get(list(self.skills.get(self.playerElement))[i])))

            if checker <= 3 and flag == 0:
                while True:
                    skillchoice = input("Cast a spell: ")
                    if skillchoice in self.spamCheckerForPlayer:
                        continue
                    else:
                        self.spamCheckerForPlayer += skillchoice
                        break

                yourthrownskill = list(self.skills.get(self.playerElement))[int(skillchoice)]
                yourskilldamage = self.skills.get(self.playerElement).get(list(self.skills.get(self.playerElement))[int(skillchoice)])

                self.timer_for_dramatics()
                if yourthrownskill != "Dragon Scale":
                    print("You casted {} on computer! he received {} damage!".format(yourthrownskill, yourskilldamage))
                    print("Your health = {} || Computer health = {}".format(self.playerHealth,(self.computerHealth-yourskilldamage)))
                    self.computerHealth -= yourskilldamage
                else:
                    print("You used dragon scale! healed by 300 hp!")
                    print("Your health = {} || Computer health = {}".format((self.playerHealth+yourskilldamage),self.computerHealth))
                    self.playerHealth += yourskilldamage
            else:
                self.timer_for_dramatics()
                print("You successfully punched computer magi and dealt 150 damage!")
                print("Your health = {} || Computer health = {}".format(self.playerHealth,(self.computerHealth - 150)))
                self.computerHealth -= 150



print("\n\n\nWelcome to the world of MAGIS! The kingdom of three elemental wizards.\n"
      "---> FIRE the element of Destruction and Purification.\n"
      "-> Fire Elementals can cast Dragon's Breathe, Dragon's Scale, Dragon Aura, Dragon Tail, and Sun Burst!\n"
      "---> LIGHTNING the element of Swiftness and Punishment.\n"
      "-> Lightning Elementals can cast Chidori Strike, Lightning Evade, Lightning Burst, Thunder Shock, Lightning Bolt!\n"
      "---> EARTH the element of the Strong and Enduring.\n"
      "-> Earth Elementals can cast Toss, Avalance, Echo Slam, Earth Splitter, Earth Shock!")
urname = input("Before choosing an element, let us know you young magi. What's your name? ")
print("Welcome {}! Choose an element wisely child.".format(urname))
elementPower = input()
print("Well done! I expect a lot of things from you as {} elemental.".format(elementPower))
print("You can now duel with other Magis!")
gm = int(input("But First, choose a level to duel. Note: You can only have 3 skills as an element.\n"
           "[1] EASY -> Your enemy and you will have 1000 health and he can cast 3 skills\n"
           "[2] MEDIUM -> Your enemy and you will have 1500 health but he can cast 4 skills\n"
           "[3] HARD -> Your enemy and you will have 2000 health but he can cast 5 skills\nEnter choice: "))

te = theElementals(urname,gm,elementPower)
print("Prepare! your enemy is {} elemental".format(te.computerElement))

while True:
    te.playerMove()
    if te.stopgame():
        break
    else: pass
    te.computerMove()


