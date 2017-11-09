using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace BasicBattleTracking
{
    [Serializable()]
    public partial class MainWindow : Form
    {
        public List<Fighter> combatants{ get; private set; }
        public List<string> fighterOrder{ get; private set; }
        public List<Status> statusEffects{ get; private set; }
        public int combatRound{ get; private set; }
        public int activeIndex { get; private set; }
        public int selectedFighter { get; private set; }
        public int selectedStatus  { get; private set; }
        public bool holdFlag { get; private set; }
        public int savedIndex { get; private set; }
        public List<int> statuses{ get; private set; }
        public bool multiStatus { get; private set; }
        public Fighter selectedFighterObject{ get; private set; }
        public Fighter editFighter{ get; private set; }
        public int selectedAttack { get; private set; }
        public SessionController session{ get; private set; }
        

        public bool cancelInit { get; set; }

        public List<Status> recentlyUsedStatuses { get; set; }

        public List<object> Fields { get; set; }
        public MainWindow()
        {
            session = new SessionController(this);
            BattleIO settingsLoader = new BattleIO();
            session.settings = settingsLoader.LoadAutoSettings();
            combatRound = 0;
            activeIndex = 0;
            selectedStatus = 0;
            holdFlag = false;
            savedIndex = 0;
            multiStatus = false;
            selectedAttack = 0;
            InitializeComponent();
            skillsTab1.ParentWindow = this;
            notesTab1.sendSettings(session.settings);
            this.FormClosing += new FormClosingEventHandler(this.Form1_Closing);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InitOrderView.SelectedIndices.Count > 0)
            {
                selectedFighter = InitOrderView.SelectedIndices[0];
                if(selectedFighter < fighterOrder.Count)
                {
                    unholdButton.Text = "Unhold " + fighterOrder.ElementAt(selectedFighter);
                    updateFighterInfo(selectedFighter);
                    UpdateFighterList();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            combatants = new List<Fighter>();
            fighterOrder = new List<string>();
            statusEffects = new List<Status>();
            recentlyUsedStatuses = new List<Status>();
            cancelInit = false;
            statuses = new List<int>();
            selectedFighterObject = new Fighter("Alex", 0, true);
            AutoLoad();
            this.FormClosed += new FormClosedEventHandler(this.MainWindow_Close);
            this.removeCharacterToolStripMenuItem.DropDownItemClicked += new ToolStripItemClickedEventHandler(this.SubMenuClick);
            this.editCharacterToolStripMenuItem.DropDownItemClicked += new ToolStripItemClickedEventHandler(this.editMenuClick);
            //TestDPercentTable();
            WriteToLog("Roses are red. True love is rare. Booty booty booty booty rockin' everywhere.");
            session.SetDirty(false);
        }



        

        private void addFighterButton_Click(object sender, EventArgs e)
        {
            AddPCFunction();
        }

        private void AddPCFunction()
        {
            AddFighterWindow add = new AddFighterWindow(this);
            add.ShowDialog();
            
            enableGlobalButtons();
            AutoSave();
        }

        private void removeFighterButton_Click(object sender, EventArgs e)
        {
            if (selectedFighter != null)
            {
                RemoveSelectedFighter(combatants.ElementAt(selectedFighter));
            }
        }

        private void RemoveSelectedFighter(Fighter selected)
        {
            if (combatants.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Are you sure?", "Remove " + selected.Name, MessageBoxButtons.OKCancel);
                if (confirm == DialogResult.OK)
                {
                    WriteToLog("Removed " + selected.Name + ".");
                    selected.StatusEffects.Clear();
                    removeFighter(selected);
                    if (selectedFighter > 0)
                    {
                        selectedFighter--;
                    }
                    else
                    {
                        selectedFighter = 0;
                    }

                    if (combatants.Count <= 0)
                    {
                        disableTurnButtons();
                        initButton.Enabled = false;
                        SetRollButtons(false);
                    }
                    else
                    {
                        updateFighterInfo(selectedFighter);
                    }
                }
                AutoSave();
            }
        }

        public void AddFighter(Fighter newFighter)
        {
            combatants.Add(newFighter);
            UpdateFighterList();
        }

        private void UpdateFighterList()
        {
            InitOrderView.Items.Clear();
            List<Fighter> orderedFighterList = combatants.OrderByDescending(c => c.Initiative).ThenByDescending(c => c.Dex).ToList();
            int index = 1;
            fighterOrder.Clear();
            statusView.Items.Clear();
            statusEffects.Clear();
            foreach (Fighter f in orderedFighterList)
            {
                f.UpdateStatusTargets();
                fighterOrder.Add(f.Name);
                string held = "";
                if (f.HoldAction)
                    held = "Yes";
                else
                    held = "No";
                InitOrderView.Items.Add(new ListViewItem(new string[] { index.ToString(), f.Name, f.Initiative.ToString(), f.HP.ToString(), held }));
                index++;

                if (f.StatusEffects.Count > 0)
                {
                    foreach (Status s in f.StatusEffects)
                    {

                        statusView.Items.Add(new ListViewItem(new string[] { s.Name, f.Name, s.Turns.ToString(), s.Description }));
                        statusEffects.Add(s);
                    }
                }
            }
            //Add Items to removed and edit Fighter Menus
            List<Fighter> alphabetizedFighterList = combatants.OrderBy(c => c.Name).ToList();
            removeCharacterToolStripMenuItem.DropDownItems.Clear();
            editCharacterToolStripMenuItem.DropDownItems.Clear();
            foreach (Fighter f in alphabetizedFighterList)
            {
                removeCharacterToolStripMenuItem.DropDownItems.Add(f.Name);
                editCharacterToolStripMenuItem.DropDownItems.Add(f.Name);
            }
            if (statusView.Items.Count <= 0)
            {
                setRemoveStatusButton(false);
                RemoveStatusButton.Text = "Remove Status";
            }
            combatants = orderedFighterList;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RollInit();
            AutoSave();

        }

        private void RollInit()
        {
            cancelInit = false;
            List<Fighter> PCs = new List<Fighter>();
            List<Fighter> Enemies = new List<Fighter>();

            foreach (Fighter f in combatants)
            {
                if (f.isPC)
                    PCs.Add(f);
                else
                    Enemies.Add(f);
            }

            combatants.Clear();

            PC_Initiative initWindow = new PC_Initiative(this);
            initWindow.setPCList(PCs);

            Random randy = new Random();

            foreach (Fighter enemy in Enemies)
            {
                enemy.Initiative = (randy.Next(20) + 1 + enemy.InitBonus);
                foreach (Attack atk in enemy.attacks)
                {
                    atk.atkCount = 0;
                }
                combatants.Add(enemy);
            }

            initWindow.ShowDialog();
            UpdateFighterList();

            if (cancelInit)
            {
                return;
            }
            else
            {

                combatRound++;
                activeIndex = 0;

                turnLabel.Text = combatRound.ToString();
                WriteToLog("===============  Start of turn " + combatRound.ToString() + "  ===============");
                WriteToLog("ROLLED INITIATIVE");
                foreach (Fighter f in combatants)
                {
                    WriteToLog(f.Name + " rolls " + f.Initiative.ToString() + ".");
                }

                WriteToLog("");
                WriteToLog(fighterOrder.ElementAt(0) + " will go first");

                activeLabel.Text = fighterOrder.ElementAt(0);

                enableTurnButtons();

                //update status effects
                foreach (Fighter f in combatants)
                {
                    if (f.StatusEffects.Count > 0)
                    {
                        foreach (Status effect in f.StatusEffects)
                        {
                            effect.Turns--;
                        }
                    }
                    f.HoldAction = false;
                }
            }
            selectedFighter = activeIndex;
            updateFighterInfo(activeIndex);
            
            
        }

        public void AddMultipleFighters(List<Fighter> fList)
        {
            foreach (Fighter f in fList)
            {
                combatants.Add(f);
            }

            UpdateFighterList();
        }

        private void AttackButton_Click(object sender, EventArgs e)
        {

            AttackForm newAttack = new AttackForm(this, combatants);
            newAttack.ShowDialog();

            UpdateFighterList();
            AutoSave();
        }

        public void WriteToLog(string text)
        {
            LogBox.AppendText(text);
            LogBox.AppendText(Environment.NewLine);
            session.SetDirty(true);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        //NEXT button
        private void button4_Click(object sender, EventArgs e)
        {

            AdvanceFighter();
            
        }

        private void AdvanceFighter()
        {
            if (holdFlag)
            {
                activeIndex = savedIndex;
                holdFlag = false;
            }
            else
            {
                activeIndex++;
            }
            bool showNext = true;
            
            if (activeIndex >= fighterOrder.Count)
            {
                activeIndex = 0;
                if (session.settings.initEachRound)
                {
                    DialogResult confirmnInit = MessageBox.Show("End of initiative order. Roll next round?", "End of Round", MessageBoxButtons.YesNo);
                    if (confirmnInit == DialogResult.Yes)
                    {
                        RollInit();
                        showNext = false;
                    }
                }
                else
                {
                    combatRound++;
                    if(combatRound > 9999)
                    {
                        combatRound = 9999;
                    }
                    activeIndex = 0;

                    turnLabel.Text = combatRound.ToString();
                    WriteToLog("===============  Start of turn " + combatRound.ToString() + "  ===============");
                }
                foreach (Fighter f in combatants)
                {
                    foreach (Status s in f.StatusEffects)
                    {
                        s.Turns--;
                    }
                }
                AutoSave();
            }
            activeLabel.Text = fighterOrder.ElementAt(activeIndex);
            if(showNext)
            {
                WriteToLog(fighterOrder.ElementAt(activeIndex) + " will go next.");

                for (int i = 0; i < combatants.ElementAt(activeIndex).StatusEffects.Count; i++)
                {
                    Status effect = combatants.ElementAt(activeIndex).StatusEffects.ElementAt(i);
                    if (combatants.ElementAt(activeIndex).StatusEffects.ElementAt(i).Turns <= 0)
                    {

                        combatants.ElementAt(activeIndex).StatusEffects.RemoveAt(i);
                        WriteToLog(combatants.ElementAt(activeIndex).Name + " is no longer affected by " + effect.Name + "!");
                    }
                    else
                    {
                        WriteToLog(combatants.ElementAt(activeIndex).Name + " is affected by " + effect.Name + "! Effects: " + effect.Description);
                    }
                }

                UpdateFighterList();
            }
            selectedFighter = activeIndex;
            updateFighterInfo(activeIndex);

            
        }

        private void LogBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void removeFighter(Fighter element)
        {
            if (combatants.IndexOf(element) <= activeIndex)
                activeIndex--;
            combatants.Remove(element);
            UpdateFighterList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PreviousFigher();
            AutoSave();
            
        }

        private void PreviousFigher()
        {
            activeIndex--;
            if (activeIndex < 0)
            {
                activeIndex = fighterOrder.Count - 1;

            }
            activeLabel.Text = fighterOrder.ElementAt(activeIndex);

            WriteToLog(fighterOrder.ElementAt(activeIndex) + " will go next.");

            updateFighterInfo(activeIndex);
            selectedFighter = activeIndex;
        }

        public void enableGlobalButtons()
        {
            if (combatants.Count > 0)
            {
                initButton.Enabled = true;
                removeFighterButton.Enabled = true;
                addFighterButton.Enabled = true;
                editButton.Enabled = true;
                removeCharacterToolStripMenuItem.Enabled = true;
                rollInitiativeToolStripMenuItem.Enabled = true;
                editCharacterToolStripMenuItem.Enabled = true;
            }
        }

        public void enableTurnButtons()
        {
            AttackButton.Enabled = true;
            holdButton.Enabled = true;
            nextButton.Enabled = true;
            prevButton.Enabled = true;
            statusButton.Enabled = true;
            unholdButton.Enabled = true;
            nextTurnToolStripMenuItem.Enabled = true;
            previousTurnToolStripMenuItem.Enabled = true;
            setToTurn1ToolStripMenuItem.Enabled = true;
            
        }

        public void disableTurnButtons()
        {
            AttackButton.Enabled = false;
            holdButton.Enabled = false;
            nextButton.Enabled = false;
            prevButton.Enabled = false;
            statusButton.Enabled = false;
            unholdButton.Enabled = false;
            nextTurnToolStripMenuItem.Enabled = false;
            previousTurnToolStripMenuItem.Enabled = false;
            rollInitiativeToolStripMenuItem.Enabled = false;
            editCharacterToolStripMenuItem.Enabled = false;
            removeCharacterToolStripMenuItem.Enabled = false;
        }

        private void AutoSave()
        {
                       
            BattleIO auto = new BattleIO();



            bool[] checkboxSettings = new bool[] { AtkStrBonusBox.Checked, AtkDexBonusBox.Checked, DmgStrBonusBox.Checked, DmgDexBonusBox.Checked };

            foreach (Fighter f in combatants)
            {
                foreach (Attack atk in f.attacks)
                {
                    if(checkboxSettings[0])
                    {
                        atk.ResetAtkStrBonus();
                    }
                    if(checkboxSettings[1])
                    {
                        atk.ResetAtkDexBonus();
                    }
                    if(checkboxSettings[2])
                    {
                        atk.ResetDmgStrBonus();
                    }
                    if(checkboxSettings[3])
                    {
                        atk.ResetDmgDexBonus();
                    }
                }
            }

            //ACTUAL AUTOSAVE PART
            auto.AutoSave(combatants, checkboxSettings, session.settings, this);
            auto.SaveRecentlyUsedStatuses(recentlyUsedStatuses, session.settings);
            dPercentTableControls.AutoSave();
            //Reset ability bonuses
            foreach (Fighter f in combatants)
            {
                foreach (Attack atk in f.attacks)
                {
                    if (checkboxSettings[0])
                    {
                        atk.UpdateStrBonusToAttack(Program.getAbilityMod(f.Str));
                    }
                    if (checkboxSettings[1])
                    {
                        atk.UpdateDexBonusToAttack(Program.getAbilityMod(f.Dex));
                    }
                    if (checkboxSettings[2])
                    {
                        atk.UpdateStrBonusToDamage(Program.getAbilityMod(f.Str));
                    }
                    if (checkboxSettings[3])
                    {
                        atk.UpdateDexBonusToDamage(Program.getAbilityMod(f.Dex));
                    }
                }
            }
            //WriteToLog("Autosaved.");
        }

        private void AutoLoad()
        {
            BattleIO auto = new BattleIO();
            combatants = auto.AutoLoad(this);

            

            //
            //DPercent Load
            //
            List<DPercentTable> autoDPercent = auto.AutoLoadDPercent(session.settings);
            if (autoDPercent != null)
            {
                if (autoDPercent.Count > 0)
                {
                    foreach (DPercentTable table in autoDPercent)
                    {
                        dPercentTableControls.addDPercentTable(table);
                    }
                }
            }
            
            //
            //End DPercent Load
            //

            if (combatants.Count > 0)
            {
                UpdateFighterList();
                enableGlobalButtons();
                enableTurnButtons();
            }

            foreach (Fighter f in combatants)
            {
                foreach (Attack atk in f.attacks)
                {
                    if (AtkStrBonusBox.Checked)
                    {
                        atk.UpdateStrBonusToAttack(Program.getAbilityMod(f.Str));
                    }
                    if (AtkDexBonusBox.Checked)
                    {
                        atk.UpdateDexBonusToAttack(Program.getAbilityMod(f.Dex));
                    }
                    if (DmgStrBonusBox.Checked)
                    {
                        atk.UpdateStrBonusToDamage(Program.getAbilityMod(f.Str));
                    }
                    if (DmgDexBonusBox.Checked)
                    {
                        atk.UpdateDexBonusToDamage(Program.getAbilityMod(f.Dex));
                    }
                }
            }
            session.SetDirty(false);
        }

        public void SetCheckBoxes(bool[] checkFlags)
        {
            AtkStrBonusBox.Checked = checkFlags[0];
            AtkDexBonusBox.Checked = checkFlags[1];
            DmgStrBonusBox.Checked = checkFlags[2];
            DmgDexBonusBox.Checked = checkFlags[3];
        }

        private void MainWindow_Close(object sender, EventArgs e)
        {
            BattleIO exitLog = new BattleIO();
            exitLog.ExportLog(LogBox.Text, session.settings);
        }

        private void holdButton_Click(object sender, EventArgs e)
        {
            WriteToLog(activeLabel.Text + " holds action!");
            combatants.ElementAt(activeIndex).HoldAction = true;
            AdvanceFighter();
        }

        public void LogAttack(string victimName, int damage)
        {
            WriteToLog(activeLabel.Text + " attacked " + victimName + " for " + damage + " damage!");
        }

        private void statusButton_Click(object sender, EventArgs e)
        {
            StatusWindow addStatus = new StatusWindow(this, combatants);
            if (recentlyUsedStatuses.Count > 0)
            {
                addStatus.AddRecentlyUsed(recentlyUsedStatuses);
            }
            addStatus.ShowDialog();
            UpdateFighterList();
            if (statusView.Items.Count > 0)
                setRemoveStatusButton(true);
        }

        private void unholdButton_Click(object sender, EventArgs e)
        {
            if (combatants.ElementAt(selectedFighter).HoldAction)
            {
                savedIndex = activeIndex;
                holdFlag = true;
                activeLabel.Text = fighterOrder.ElementAt(selectedFighter);
                activeIndex = selectedFighter;
                WriteToLog(combatants.ElementAt(activeIndex).Name + " springs into action!");
                combatants.ElementAt(selectedFighter).HoldAction = false;
                UpdateFighterList();
                
            }
            else
            {
                MessageBox.Show(combatants.ElementAt(selectedFighter).Name + " has not held action. Try the next or previous buttons.", "Error");
            }
        }

        public void setRemoveStatusButton(bool state)
        {
            RemoveStatusButton.Enabled = state;
        }

        private void statusView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (statusView.SelectedIndices.Count == 1)
            {
                selectedStatus = statusView.SelectedIndices[0];
                multiStatus = false;
                statuses.Clear();
                if(selectedStatus < statusEffects.Count)
                {
                    RemoveStatusButton.Text = "Remove " + statusEffects.ElementAt(selectedStatus).Name;
                }
                RemoveStatusButton.Enabled = true;
            }
            else if (statusView.SelectedIndices.Count > 1)
            {
                RemoveStatusButton.Text = "Remove Multiple";
                statuses.Clear();
                multiStatus = true;
                foreach (int i in statusView.SelectedIndices)
                {
                    statuses.Add(i);
                }
                RemoveStatusButton.Enabled = true;
            }
        }

        private void RemoveStatusButton_Click(object sender, EventArgs e)
        {
            if(statusView.Items.Count > 0)
            {
                if (multiStatus == false)
                {
                    Status removed = statusEffects.ElementAt(selectedStatus);
                    Fighter victim = removed.GetTarget();
                    victim.StatusEffects.Remove(removed);
                    UpdateFighterList();

                    if (statusView.Items.Count <= 0)
                    {
                        setRemoveStatusButton(false);
                        RemoveStatusButton.Text = "Remove Status";
                    }
                }
                else
                {
                    for (int i = statusEffects.Count; i >=0; i--)
                    {
                        if(statuses.Contains(i))
                        {
                        Status removed = statusEffects.ElementAt(i);
                        Fighter victim = removed.GetTarget();
                        victim.StatusEffects.Remove(removed);
                        UpdateFighterList();

                        if (statusView.Items.Count <= 0)
                        {
                            setRemoveStatusButton(false);
                            RemoveStatusButton.Text = "Remove Status";
                        }
                     }
                    }
                    multiStatus = false;
                }
                RemoveStatusButton.Enabled = false;
            }
            AutoSave();
        }

        public void AddStatus(Status status)
        {
            statusEffects.Add(status);

            bool unique = true;
            foreach(Status s in recentlyUsedStatuses)
            {
                if (s.Name == status.Name)
                    unique = false;
            }

            if(unique)
            {
                recentlyUsedStatuses.Add(status);
                if (recentlyUsedStatuses.Count > 100)
                    recentlyUsedStatuses.RemoveAt(0);
            }
            AutoSave();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            AddNPCFunction();
        }
        private void AddNPCFunction()
        {
            StatBlockDesigner sbd = new StatBlockDesigner();
            sbd.parent = this;
            sbd.Show();
            AutoSave();
        }

        private void SetRollButtons(bool setting)
        {
            CMBButton.Enabled = setting;
            FortButton.Enabled = setting;
            RefButton.Enabled = setting;
            WillButton.Enabled = setting;
            npcAttackButton.Enabled = setting;
        }

        private void CMBButton_Click(object sender, EventArgs e)
        {
            SetDamageInfoEnable(false);
            WriteToRollConsole("=====Combat Maneuver=====");
            Random randy = new Random();
            int result = randy.Next(20) + 1;
            d20Label.Text = result.ToString();
            WriteToRollConsole("Roll: " + result.ToString());
            WriteToRollConsole("Modifier: " + combatants.ElementAt(selectedFighter).CMB.ToString());
            atkModBox.Text = combatants.ElementAt(selectedFighter).CMB.ToString();
            result += combatants.ElementAt(selectedFighter).CMB;
            WriteToRollConsole("");
            WriteToRollConsole("Total: " + result.ToString());
            WriteToRollConsole("");
            rollResultLabel.Text = result.ToString();
            WriteToLog(combatants.ElementAt(selectedFighter).Name + " made a combat maneuver check of " + result.ToString() + "!");
        }

        private void FortButton_Click(object sender, EventArgs e)
        {
            SetDamageInfoEnable(false);
            WriteToRollConsole("=====Fortitude Save=====");
            Random randy = new Random();
            int result = randy.Next(20) + 1;
            d20Label.Text = result.ToString();
            WriteToRollConsole("Roll: " + result.ToString());
            WriteToRollConsole("Modifier: " + combatants.ElementAt(selectedFighter).fort.ToString());
            atkModBox.Text = combatants.ElementAt(selectedFighter).fort.ToString();
            result += combatants.ElementAt(selectedFighter).fort;
            WriteToRollConsole("");
            WriteToRollConsole("Total: " + result.ToString());
            WriteToRollConsole("");
            rollResultLabel.Text = result.ToString();
            WriteToLog(combatants.ElementAt(selectedFighter).Name + " made a Fortitude Save of " + result.ToString() + "!");
        }

        private void RefButton_Click(object sender, EventArgs e)
        {
            SetDamageInfoEnable(false);
            WriteToRollConsole("=====Reflex Save=====");
            Random randy = new Random();
            int result = randy.Next(20) + 1;
            d20Label.Text = result.ToString();
            WriteToRollConsole("Roll: " + result.ToString());
            WriteToRollConsole("Modifier: " + combatants.ElementAt(selectedFighter).reflex.ToString());
            atkModBox.Text = combatants.ElementAt(selectedFighter).reflex.ToString();
            result += combatants.ElementAt(selectedFighter).reflex;
            WriteToRollConsole("");
            WriteToRollConsole("Total: " + result.ToString());
            WriteToRollConsole("");
            rollResultLabel.Text = result.ToString();
            WriteToLog(combatants.ElementAt(selectedFighter).Name + " made a Reflex Save of " + result.ToString() + "!");
        }

        private void WillButton_Click(object sender, EventArgs e)
        {
            SetDamageInfoEnable(false);
            WriteToRollConsole("=====Will Save=====");
            Random randy = new Random();
            int result = randy.Next(20) + 1;
            d20Label.Text = result.ToString();
            WriteToRollConsole("Roll: " + result.ToString());
            WriteToRollConsole("Modifier: " + combatants.ElementAt(selectedFighter).will.ToString());
            atkModBox.Text = combatants.ElementAt(selectedFighter).will.ToString();
            result += combatants.ElementAt(selectedFighter).will;
            WriteToRollConsole("");
            WriteToRollConsole("Total: " + result.ToString());
            WriteToRollConsole("");
            rollResultLabel.Text = result.ToString();
            WriteToLog(combatants.ElementAt(selectedFighter).Name + " made a Will Save of " + result.ToString() + "!");
        }


        private void RollAttack(Attack atk, bool crit)
        {
            SetDamageInfoEnable(true);
            int dieTotal = atk.RollDamage();
            WriteToRollConsole("Rolling " + atk.dieAmt.ToString() + " d" + atk.dieType.ToString() + " for damage");
            int subtotal = 0;
            StringBuilder sb = new StringBuilder("Result: " + atk.RawDamageTotal);
            sb.Append(" {");
            for (int i = 0; i < atk.dieAmt; i++)
            {
                sb.Append(atk.damageRollResults.ElementAt(i).ToString());
                if(i != atk.dieAmt - 1)
                {
                    sb.Append(", ");
                }
                else
                {
                    sb.Append("}");
                }
                subtotal += atk.damageRollResults.ElementAt(i);
            }
            WriteToRollConsole(sb.ToString());
            rawDamageBox.Text = subtotal.ToString();
            dmgBonusBox.Text = atk.dmgBonus.ToString();
            WriteToRollConsole("Damage Bonus: " + atk.dmgBonus.ToString());
            DamageLabel.Text = dieTotal.ToString();

            if (crit)
            {
                WriteToLog("Critical Hit!");
                int confirm = atk.ConfirmCritCheck();
                WriteToRollConsole("");
                WriteToRollConsole("Potential critical hit!");
                WriteToRollConsole("Rolling 1d20 + " + atk.atkBonuses.ElementAt(atk.atkCount) + " to confirm.");
                WriteToRollConsole("Reslut: " + confirm);
                DialogResult critConfirm = MessageBox.Show("Confirm check is " + confirm + ". Confirm critical?", "Critical Hit!", MessageBoxButtons.YesNo);
                if (critConfirm == DialogResult.Yes)
                {
                    WriteToRollConsole("Critical hit confirmed! Multiplier: " + atk.CritMult.ToString());
                    WriteToLog("It was confirmed!");
                    dieTotal *= atk.CritMult;

                    int newRawDamage = Int32.Parse(rawDamageBox.Text) * atk.CritMult;
                    int newDamageBonus = Int32.Parse(dmgBonusBox.Text) * atk.CritMult;

                    rawDamageBox.Text = newRawDamage.ToString();
                    dmgBonusBox.Text = newDamageBonus.ToString();

                }
                else
                {
                    WriteToRollConsole("Critical hit not confirmed!");
                    WriteToLog("It was not confirmed!");
                }
                
            }

            DamageLabel.Text = dieTotal.ToString();
            WriteToRollConsole("Grand Total: " + dieTotal.ToString());
        }

        private void PrepareAttack(int atkIndex)
        {
            Attack atk = combatants.ElementAt(selectedFighter).attacks.ElementAt(atkIndex);
            WriteToRollConsole("=====ATTACK ROLL=====");
            WriteToRollConsole("Rolled 1 d20");
            bool crit = false;
            int result = atk.RollAttack();
            atkModBox.Text = atk.atkBonuses.ElementAt(atk.atkCount - 1).ToString();
            WriteToRollConsole("Result: " + atk.AtkRollResult);
            WriteToRollConsole("Modifier: " + atk.atkBonuses.ElementAt(atk.atkCount - 1));
            WriteToRollConsole("Total: " + result.ToString() + "\n");
            if (atk.AtkRollResult >= atk.CritMin)
            {
                crit = true;
                
            }
            
            rollResultLabel.Text = result.ToString();
            d20Label.Text = atk.AtkRollResult.ToString();
            WriteToLog(combatants.ElementAt(selectedFighter).Name + " made an attack using " + combatants.ElementAt(selectedFighter).attacks.ElementAt(atkIndex).name + " with a roll of " + result.ToString() + "!");

            RollAttack(combatants.ElementAt(selectedFighter).attacks.ElementAt(atkIndex), crit);
        }

        private void updateFighterInfo(int fighterIndex)
        {
            if (combatants.Count > 0)
            {
                Fighter update = combatants.ElementAt(fighterIndex);
                selectedFighterObject = update;
                fighterInfoBox.Text = selectedFighterObject.Name + " Stats";
                attackView.Items.Clear();
                UpdateSkills();
                if (!update.isPC)
                {
                    SetRollButtons(true);
                    UpdateAtkValues(fighterIndex);
                    //if (combatants.ElementAt(fighterIndex).attacks.Count > 0)
                    //{
                    //    A1Button.Enabled = true;
                    //    A1Button.Text = combatants.ElementAt(fighterIndex).attacks.ElementAt(0).name;
                    //}
                    //if (combatants.ElementAt(fighterIndex).attacks.Count > 1)
                    //{
                    //    A2Button.Enabled = true;
                    //    A2Button.Text = combatants.ElementAt(fighterIndex).attacks.ElementAt(1).name;
                    //}
                    //if (combatants.ElementAt(fighterIndex).attacks.Count > 2)
                    //{
                    //    A3Button.Enabled = true;
                    //    A3Button.Text = combatants.ElementAt(fighterIndex).attacks.ElementAt(2).name;
                    //}


                }
                else
                {
                    SetRollButtons(false);
                    AtkNameLabel.Text = "Attack";
                    //A1Button.Enabled = false;
                    //A2Button.Enabled = false;
                    //A3Button.Enabled = false;
                    //A1Button.Text = "None";
                    //A2Button.Text = "None";
                    //A3Button.Text = "None";
                }


                hpLabel.Text = update.HP.ToString();
                acLabel.Text = update.AC.ToString();
                flatFootedLabel.Text = update.FlatFootedAC.ToString();
                touchLabel.Text = update.TouchAC.ToString();
                cmbLabel.Text = update.CMB.ToString();
                cmdLabel.Text = update.CMD.ToString();
                initBox.Text = update.InitBonus.ToString();
                fortBox.Text = update.fort.ToString();
                refBox.Text = update.reflex.ToString();
                willBox.Text = update.will.ToString();
                npcNameBox.Text = update.Name;
                npcSPBox.Text = update.SpellPoints.ToString();
                npcSRBox.Text = update.SpellResist.ToString();
                npcNegLevelsBox.Text = update.NegativeLevels.ToString();
                drBox.Text = update.DamageReduce.ToString();
                attackModBox.Text = update.attackMod.ToString();

                strBox.Text = update.Str.ToString();
                dexBox.Text = update.Dex.ToString();
                conBox.Text = update.Con.ToString();
                intBox.Text = update.Int.ToString();
                wisBox.Text = update.Wis.ToString();
                chaBox.Text = update.Cha.ToString();

                displayMod(strBox, strModBox);
                displayMod(dexBox, dexModBox);
                displayMod(conBox, conModBox);
                displayMod(intBox, intModBox);
                displayMod(wisBox, wisModBox);
                displayMod(chaBox, chaModBox);

                bioBox.Text = update.Notes;
            }
        }

        private void UpdateSkills()
        {
            skillsTab1.SetActiveFighter(selectedFighterObject);
            skillsTab1.UpdateSkillsList();
        }

        private void WriteToRollConsole(string text)
        {
            rollBox.AppendText(text);
            rollBox.AppendText(Environment.NewLine);
        }

        private void npcAttackButton_Click(object sender, EventArgs e)
        {
            if (selectedAttack < combatants.ElementAt(selectedFighter).attacks.Count)
            {
                PrepareAttack(selectedAttack);
                updateFighterInfo(selectedFighter);
            }
        }

        private void attackView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (attackView.SelectedIndices.Count > 0)
            {
                if (attackView.SelectedIndices[0] >= 0)
                {
                    selectedAttack = attackView.SelectedIndices[0];
                    AtkNameLabel.Text = combatants.ElementAt(selectedFighter).attacks.ElementAt(selectedAttack).name;
                }
            }
        }


        //
        //Stat Update Functions
        //
        private void hpLabel_TextChanged_1(object sender, EventArgs e)
        {
            if (combatants.Count > 0)
            {
                int newHP = 0;
                try
                {
                    newHP = Int32.Parse(hpLabel.Text);
                    combatants.ElementAt(selectedFighter).HP = newHP;
                }
                catch { }

                UpdateFighterList();
            }
        }

        private void acLabel_TextChanged_1(object sender, EventArgs e)
        {
            if (combatants.Count > 0)
            {
                int newVal = 0;
                try
                {
                    newVal = Int32.Parse(acLabel.Text);
                    combatants.ElementAt(selectedFighter).AC = newVal;
                }
                catch { }

            }
        }

        private void flatFootedLabel_TextChanged_1(object sender, EventArgs e)
        {
            if (combatants.Count > 0)
            {
                if (!combatants.ElementAt(selectedFighter).isPC)
                {
                    int newVal = 0;
                    try
                    {
                        newVal = Int32.Parse(flatFootedLabel.Text);
                        combatants.ElementAt(selectedFighter).FlatFootedAC = newVal;
                    }
                    catch { }
                }
            }
        }

        private void touchLabel_TextChanged_1(object sender, EventArgs e)
        {
            if (combatants.Count > 0)
            {
                int newVal = 0;
                try
                {
                    newVal = Int32.Parse(touchLabel.Text);
                    combatants.ElementAt(selectedFighter).TouchAC = newVal;
                }
                catch { }

            }
        }

        private void cmbLabel_TextChanged_1(object sender, EventArgs e)
        {
            if (!combatants.ElementAt(selectedFighter).isPC)
            {
                int newVal = 0;
                try
                {
                    newVal = Int32.Parse(cmbLabel.Text);
                    combatants.ElementAt(selectedFighter).CMB = newVal;
                }
                catch { }
            }
        }

        private void cmdLabel_TextChanged_1(object sender, EventArgs e)
        {
            if (combatants.Count > 0)
            {
                int newVal = 0;
                try
                {
                    newVal = Int32.Parse(cmdLabel.Text);
                    combatants.ElementAt(selectedFighter).CMD = newVal;
                }
                catch { }

            }
        }

        private void initBox_TextChanged(object sender, EventArgs e)
        {
            if (combatants.Count > 0)
            {
                int newVal = 0;
                try
                {
                    newVal = Int32.Parse(initBox.Text);
                    combatants.ElementAt(selectedFighter).InitBonus = newVal;
                }
                catch { }

            }
        }

        private void fortBox_TextChanged_1(object sender, EventArgs e)
        {
            if (combatants.Count > 0)
            {
                int newVal = 0;
                try
                {
                    newVal = Int32.Parse(fortBox.Text);
                    combatants.ElementAt(selectedFighter).fort = newVal;
                }
                catch { }

            }
        }

        private void refBox_TextChanged_1(object sender, EventArgs e)
        {
            if (combatants.Count > 0)
            {
                int newVal = 0;
                try
                {
                    newVal = Int32.Parse(refBox.Text);
                    combatants.ElementAt(selectedFighter).reflex = newVal;
                }
                catch { }

            }
        }

        private void willBox_TextChanged_1(object sender, EventArgs e)
        {
            if (combatants.Count > 0)
            {
                int newVal = 0;
                try
                {
                    newVal = Int32.Parse(willBox.Text);
                    combatants.ElementAt(selectedFighter).will = newVal;
                }
                catch { }

            }
        }
        private void hpLabel_TextChanged(object sender, EventArgs e)
        {

        }

        private void acLabel_TextChanged(object sender, EventArgs e)
        {

        }

        private void flatFootedLabel_TextChanged(object sender, EventArgs e)
        {

        }

        private void touchLabel_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbLabel_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdLabel_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void fortBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void refBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void willBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void displayMod(TextBox inputBox, TextBox outputBox)
        {
            int score = 0;
            try
            {
                score = Int32.Parse(inputBox.Text);
            }
            catch
            {
                return;
            }

            int mod = Program.getAbilityMod(score);

            if (mod >= 0)
            {
                outputBox.Text = "+" + mod.ToString();
                outputBox.ForeColor = SystemColors.WindowText;
            }
            else
            {
                outputBox.Text = "-" + mod.ToString();
                outputBox.ForeColor = Color.Red;
            }
        }

        private void strBox_TextChanged_1(object sender, EventArgs e)
        {
            if (combatants.Count > 0)
            {

                int newVal = 0;
                try
                {
                    newVal = Int32.Parse(strBox.Text);
                    combatants.ElementAt(selectedFighter).Str = newVal;

                    WriteAbilityChangeToSkills(newVal, "Str");
                    if (AtkStrBonusBox.Checked)
                    {
                        foreach (Attack atk in selectedFighterObject.attacks)
                        {
                            atk.UpdateStrBonusToAttack(Program.getAbilityMod(newVal));
                        }
                    }
                    if (DmgStrBonusBox.Checked)
                    {
                        foreach (Attack atk in selectedFighterObject.attacks)
                        {
                            atk.UpdateStrBonusToDamage(Program.getAbilityMod(newVal));
                        }
                    }
                }
                catch { }
            }
            displayMod(strBox, strModBox);
            UpdateAtkValues(selectedFighter);
        }

        private void dexBox_TextChanged_1(object sender, EventArgs e)
        {
            if (combatants.Count > 0)
            {

                int newVal = 0;
                try
                {
                    newVal = Int32.Parse(dexBox.Text);
                    combatants.ElementAt(selectedFighter).Dex = newVal;
                    WriteAbilityChangeToSkills(newVal, "Dex");

                    if (AtkDexBonusBox.Checked)
                    {
                        foreach (Attack atk in selectedFighterObject.attacks)
                        {
                            atk.UpdateDexBonusToAttack(Program.getAbilityMod(newVal));
                        }
                    }
                    if (DmgDexBonusBox.Checked)
                    {
                        foreach (Attack atk in selectedFighterObject.attacks)
                        {
                            atk.UpdateDexBonusToDamage(Program.getAbilityMod(newVal));
                        }
                    }
                }
                catch { }

            }
            displayMod(dexBox, dexModBox);
            UpdateAtkValues(selectedFighter);
        }

        private void conBox_TextChanged_1(object sender, EventArgs e)
        {
            if (combatants.Count > 0)
            {
                int newVal = 0;
                try
                {
                    newVal = Int32.Parse(conBox.Text);
                    combatants.ElementAt(selectedFighter).Con = newVal;
                    WriteAbilityChangeToSkills(newVal, "Con");
                }
                catch { }

            }
            displayMod(conBox, conModBox);
            UpdateAtkValues(selectedFighter);
        }

        private void intBox_TextChanged_1(object sender, EventArgs e)
        {
            if (combatants.Count > 0)
            {

                int newVal = 0;
                try
                {
                    newVal = Int32.Parse(intBox.Text);
                    combatants.ElementAt(selectedFighter).Int = newVal;
                    WriteAbilityChangeToSkills(newVal, "Int");
                }
                catch { }

            }
            displayMod(intBox, intModBox);
            UpdateAtkValues(selectedFighter);
        }

        private void wisBox_TextChanged_1(object sender, EventArgs e)
        {
            if (combatants.Count > 0)
            {

                int newVal = 0;
                try
                {
                    newVal = Int32.Parse(wisBox.Text);
                    combatants.ElementAt(selectedFighter).Wis = newVal;
                    WriteAbilityChangeToSkills(newVal, "Wis");
                }
                catch { }

            }
            displayMod(wisBox, wisModBox);
            UpdateAtkValues(selectedFighter);
        }

        private void chaBox_TextChanged_1(object sender, EventArgs e)
        {
            if (!combatants.ElementAt(selectedFighter).isPC)
            {
                int newVal = 0;
                try
                {
                    newVal = Int32.Parse(chaBox.Text);
                    combatants.ElementAt(selectedFighter).Cha = newVal;
                    WriteAbilityChangeToSkills(newVal, "Cha");
                }
                catch { }

            }
            displayMod(chaBox, chaModBox);
            UpdateAtkValues(selectedFighter);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            selectedFighterObject.Name = npcNameBox.Text;
            editFighter = selectedFighterObject;
            UpdateFighter(selectedFighterObject);
        }

        private void npcSPBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int newVal = Int32.Parse(npcSPBox.Text);
                selectedFighterObject.SpellPoints = newVal;
                updateFighterInfo(selectedFighter);
            }
            catch { }
           
        }

        private void npcNegLevelsBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int negativeLvls = Int32.Parse(npcNegLevelsBox.Text);
                selectedFighterObject.ApplyNegativeLevels(negativeLvls);
                updateFighterInfo(selectedFighter);
            }
            catch
            {

            }
            
        }
        private void bioBox_TextChanged(object sender, EventArgs e)
        {
            selectedFighterObject.Notes = bioBox.Text;
        }
        //Attack Mod Box
        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            int newMod = 0;
            try
            {
                newMod = Int32.Parse(attackModBox.Text);
                selectedFighterObject.ApplyGlobalAttackMod(newMod);
                UpdateAtkValues(selectedFighter);
            }
            catch { }

        }

        private void WriteAbilityChangeToSkills(int newAbilityScore, string abilityName)
        {
            foreach(Skill s in selectedFighterObject.skills)
            {
                if(s.abilitySource == abilityName)
                {
                    s.abilityMod = Program.getAbilityMod(newAbilityScore);
                }
            }
            UpdateSkills();
            skillsTab1.UpdateSelectedSkill();
        }

        //
        //End of Stat Update Functions
        //

        private void RollGeneric(int type, int amt, int bonus, TextBox resultBox)
        {
            DiceRoller dr = new DiceRoller(amt, type, bonus);
            int result = dr.RollDice();
            WriteToRollConsole("");
            WriteToRollConsole("=====Generic Roll=====");
            WriteToRollConsole("Rolling " + amt.ToString() + " d" + type.ToString());
            WriteToRollConsole("");
            WriteToRollConsole("Result:\t" + dr.RawDieTotal.ToString());
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            for(int i = 0; i < dr.DiceRolls.Count; i++)
            {
                sb.Append(dr.DiceRolls.ElementAt(i).ToString());
                if(i != dr.DiceRolls.Count - 1)
                {
                    sb.Append(", ");
                }
            }
            
            sb.Append("}");
            WriteToRollConsole(sb.ToString());
            WriteToRollConsole("");
            WriteToRollConsole("Modifier: " + bonus.ToString());
            WriteToRollConsole("Total: " + result.ToString());
            resultBox.Text = result.ToString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void SetDamageInfoEnable(bool value)
        {
            rawDamageLabel.Enabled = value;
            rawDamageBox.Enabled = value;
            dmgBonusLabel.Enabled = value;
            dmgBonusBox.Enabled = value;
            damageResult.Enabled = value;
            DamageLabel.Enabled = value;
        }

        //
        //Start Die Roll Buttons
        //
        private void button1_Click_1(object sender, EventArgs e)
        {
            int amt = 1;
            int mod = 0;
            try
            {
                amt = Int32.Parse(d20CountBox.Text);
                mod = Int32.Parse(d20ModBox.Text);
            }
            catch
            {
                d20CountBox.Text = "1";
                d20ModBox.Text = "0";
            }
            finally
            {
                RollGeneric(20, amt, mod, d20ResultBox);
            }
        }

        private void d4RollButton_Click(object sender, EventArgs e)
        {
            int amt = 1;
            int mod = 0;
            try
            {
                amt = Int32.Parse(d4CountBox.Text);
                mod = Int32.Parse(d4ModBox.Text);
            }
            catch
            {
                d4CountBox.Text = "1";
                d4ModBox.Text = "0";
            }
            finally
            {
                RollGeneric(4, amt, mod, d4ResultBox);
            }
        }

        private void d6ResultBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void d6RollButton_Click(object sender, EventArgs e)
        {
            int amt = 1;
            int mod = 0;
            try
            {
                amt = Int32.Parse(d6CountBox.Text);
                mod = Int32.Parse(d6ModBox.Text);
            }
            catch
            {
                d6CountBox.Text = "1";
                d6ModBox.Text = "0";
            }
            finally
            {
                RollGeneric(6, amt, mod, d6ResultBox);
            }
        }

        private void d8RollButton_Click(object sender, EventArgs e)
        {
            int amt = 1;
            int mod = 0;
            try
            {
                amt = Int32.Parse(d8CountBox.Text);
                mod = Int32.Parse(d8ModBox.Text);
            }
            catch
            {
                d8CountBox.Text = "1";
                d8ModBox.Text = "0";
            }
            finally
            {
                RollGeneric(8, amt, mod, d8ResultBox);
            }
        }

        private void d10RollButton_Click(object sender, EventArgs e)
        {
            int amt = 1;
            int mod = 0;
            try
            {
                amt = Int32.Parse(d10CountBox.Text);
                mod = Int32.Parse(d10ModBox.Text);
            }
            catch
            {
                d10CountBox.Text = "1";
                d10ModBox.Text = "0";
            }
            finally
            {
                RollGeneric(10, amt, mod, d10ResultBox);
            }
        }

        private void d12RollButton_Click(object sender, EventArgs e)
        {
            int amt = 1;
            int mod = 0;
            try
            {
                amt = Int32.Parse(d12CountBox.Text);
                mod = Int32.Parse(d12ModBox.Text);
            }
            catch
            {
                d12CountBox.Text = "1";
                d12ModBox.Text = "0";
            }
            finally
            {
                RollGeneric(12, amt, mod, d12ResultBox);
            }
        }

        private void d100RollButton_Click(object sender, EventArgs e)
        {
            int amt = 1;
            int mod = 0;
            try
            {
                amt = Int32.Parse(d100CountBox.Text);
                mod = Int32.Parse(d100ModBox.Text);
            }
            catch
            {
                d100CountBox.Text = "1";
                d100ModBox.Text = "0";
            }
            finally
            {
                RollGeneric(100, amt, mod, d100ResultBox);
            }
        }

        private void dxRollButton_Click(object sender, EventArgs e)
        {
            int amt = 1;
            int mod = 0;
            int type = 1;
            try
            {
                amt = Int32.Parse(dxCountBox.Text);
                mod = Int32.Parse(dxModBox.Text);
                type = Int32.Parse(dxTypeBox.Text);
            }
            catch 
            {
                dxCountBox.Text = "1";
                dxModBox.Text = "0";
                dxTypeBox.Text = "1";
            }
            finally
            {
                RollGeneric(type, amt, mod, dxResultBox);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionScreen options = new OptionScreen(session.settings, this);
            options.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //
        //Ability modifier checkbox controls
        //
        private void AtkStrBonusBox_CheckedChanged(object sender, EventArgs e)
        {
                if(AtkStrBonusBox.Checked)
                {
                    foreach(Fighter f in combatants)
                    {
                        if(f.attacks.Count > 0)
                        {
                            foreach(Attack atk in f.attacks)
                            {
                                atk.UpdateStrBonusToAttack(Program.getAbilityMod(f.Str));
                            }
                        }
                    }
                }
                else
                {
                    foreach(Fighter f in combatants)
                    {
                        if(f.attacks.Count > 0)
                        {
                            foreach(Attack atk in f.attacks)
                            {
                                atk.ResetAtkStrBonus();
                            }
                        }
                    }
                }
                updateFighterInfo(selectedFighter);
        }

        private void AtkDexBonusBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AtkDexBonusBox.Checked)
            {
                foreach (Fighter f in combatants)
                {
                    if (f.attacks.Count > 0)
                    {
                        foreach (Attack atk in f.attacks)
                        {
                            atk.UpdateDexBonusToAttack(Program.getAbilityMod(f.Dex));
                        }
                    }
                }
            }
            else
            {
                foreach (Fighter f in combatants)
                {
                    if (f.attacks.Count > 0)
                    {
                        foreach (Attack atk in f.attacks)
                        {
                            atk.ResetAtkDexBonus();
                        }
                    }
                }
            }
            updateFighterInfo(selectedFighter);
        }

        private void DmgStrBonusBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DmgStrBonusBox.Checked)
            {
                foreach (Fighter f in combatants)
                {
                    if (f.attacks.Count > 0)
                    {
                        foreach (Attack atk in f.attacks)
                        {
                            atk.UpdateStrBonusToDamage(Program.getAbilityMod(f.Str));
                        }
                    }
                }
            }
            else
            {
                foreach (Fighter f in combatants)
                {
                    if (f.attacks.Count > 0)
                    {
                        foreach (Attack atk in f.attacks)
                        {
                            atk.ResetDmgStrBonus();
                        }
                    }
                }
            }
            updateFighterInfo(selectedFighter);
        }

        private void DmgDexBonusBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DmgDexBonusBox.Checked)
            {
                foreach (Fighter f in combatants)
                {
                    if (f.attacks.Count > 0)
                    {
                        foreach (Attack atk in f.attacks)
                        {
                            atk.UpdateDexBonusToDamage(Program.getAbilityMod(f.Dex));
                        }
                    }
                }
            }
            else
            {
                foreach (Fighter f in combatants)
                {
                    if (f.attacks.Count > 0)
                    {
                        foreach (Attack atk in f.attacks)
                        {
                            atk.ResetDmgDexBonus();
                        }
                    }
                }
            }

            updateFighterInfo(selectedFighter);
        }

        //
        //End Ability modifier checkbox controls
        //


        private void UpdateAtkValues(int fighterIndex)
        {
            attackView.Items.Clear();
            foreach (Attack a in combatants.ElementAt(fighterIndex).attacks)
            {
                int attackCount = 0;
                if (a.atkBonuses.Count - a.atkCount > 0)
                    attackCount = a.atkBonuses.ElementAt(a.atkCount);
                else
                {
                    attackCount = a.atkBonuses.ElementAt(0);
                }
                attackView.Items.Add(new ListViewItem(new string[] { a.name, attackCount.ToString(), a.dieAmt + " d" + a.dieType + " + " + a.dmgBonus, (a.atkBonuses.Count - a.atkCount).ToString() }));
            }

            if (attackView.Items.Count > selectedAttack && combatants.ElementAt(selectedFighter).attacks.Count > 0)
            {
                AtkNameLabel.Text = combatants.ElementAt(selectedFighter).attacks.ElementAt(selectedAttack).name;
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            EditSelectedFighter(selectedFighterObject);
            
        }

        private void EditSelectedFighter(Fighter selected)
        {
            StatBlockDesigner editWindow = new StatBlockDesigner();
            editWindow.parent = this;
            if (selected != null)
            {
                editFighter = selected;
                editWindow.InitiateFighter(selected);
                editWindow.Show();
            }
            else
            {
                MessageBox.Show("No fighter selected", "Error");
            }
        }

        //
        //End Die Roll Buttons
        //
        public void UpdateFighter(Fighter update)
        {
                int index = combatants.IndexOf(editFighter);
                if (index >= 0)
                {
                    combatants.RemoveAt(index);
                    combatants.Insert(index, update);
                }
                else
                {
                    combatants.Add(update);
                    index = combatants.Count - 1;
                }
                    updateFighterInfo(index);
                
                selectedFighterObject = update;
                selectedFighter = combatants.IndexOf(update);
                UpdateFighterList();
            
        }
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!session.Exit())
            {
                e.Cancel = true;
            }
        }

        private void fighterInfoBox_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dPercentTableControls_Load(object sender, EventArgs e)
        {
            
        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        public void LoadSession(SessionDetail sendingForm)
        {
            ExtractFields(sendingForm);
            UpdateFighter(selectedFighterObject);
            updateFighterInfo(selectedFighter);
            UpdateFighterList();
        }

        public string getLog()
        {
            return LogBox.Text;
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (session.Exit())
            {
                CreateNewSession();
            }
        }
        public void CreateNewSession()
        {
            combatants.Clear();
            combatRound = 0;
            updateFighterInfo(0);
            UpdateFighterList();
            LogBox.Clear();
            WriteToLog("New Session Initialized");
            turnLabel.Text = combatRound.ToString();
            Program.activeSessionName = "New Session";
            this.Text = "Basic Battle Tracker - New Session.ssn";
            activeLabel.Text = "None";
            ResetControls();
            session.New();
            session.SetDirty(false);
        }
        public void ResetControls()
        {
            initButton.Enabled = false;
            removeFighterButton.Enabled = false;
            editButton.Enabled = false;
            removeCharacterToolStripMenuItem.Enabled = false;
            rollInitiativeToolStripMenuItem.Enabled = false;
            editCharacterToolStripMenuItem.Enabled = false;
            AttackButton.Enabled = false;
            holdButton.Enabled = false;
            nextButton.Enabled = false;
            prevButton.Enabled = false;
            statusButton.Enabled = false;
            unholdButton.Enabled = false;
            nextTurnToolStripMenuItem.Enabled = false;
            previousTurnToolStripMenuItem.Enabled = false;
            setToTurn1ToolStripMenuItem.Enabled = false;
        }

        private void openSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            session.ReinitializeSender(this);
            session.LoadSession();
            session.ReinitializeSender(this);
            session.SetDirty(false);
        }

        private void saveSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            session.ReinitializeSender(this);
            session.SaveSession(false);
        }

        //ANY TIME A NEW FIELD IS ADDED, THIS FUNCTION MUST BE UPDATED
        //VERY IMPORTANT
        //SERIOUSLY
        public List<object> CompileAndGetFields()
        {
            Fields = new List<object>();
            Fields.Add((object)combatants );
            Fields.Add((object) fighterOrder);
            Fields.Add((object) statusEffects);
            Fields.Add((object) combatRound);
            Fields.Add((object) activeIndex);
            Fields.Add((object) selectedFighter);
            Fields.Add((object) selectedStatus);
            Fields.Add((object) holdFlag);
            Fields.Add((object)savedIndex );
            Fields.Add((object)statuses );
            Fields.Add((object)multiStatus );
            Fields.Add((object) selectedFighterObject);
            Fields.Add((object)editFighter );
            Fields.Add((object) selectedAttack);
            Fields.Add((object) session);
            Fields.Add((object) cancelInit);
            Fields.Add((object)recentlyUsedStatuses);
            return Fields;
        }
        //SAME RULE APPLIES HERE
        //SERIOUSLY
        public void ExtractFields(SessionDetail sendingForm)
        {
                combatants = (List<Fighter>  ) sendingForm.combatants;
                fighterOrder = (List<string>)sendingForm.fighterOrder;
                statusEffects = (List<Status>)sendingForm.statusEffects;
                combatRound = (int)sendingForm.combatRound;
                activeIndex = (int)sendingForm.activeIndex;
                selectedFighter = (int)sendingForm.selectedFighter;
                selectedStatus = (int)sendingForm.selectedStatus;
                holdFlag = (bool)sendingForm.holdFlag;
                savedIndex = (int)sendingForm.savedIndex;
                statuses = (List<int>)sendingForm.statuses;
                multiStatus = (bool)sendingForm.multiStatus;
                selectedFighterObject = (Fighter)sendingForm.selectedFighterObject;
                editFighter = (Fighter)sendingForm.editFighter;
                selectedAttack = (int)sendingForm.selectedAttack;
                session = (SessionController)sendingForm.session;
                

                cancelInit = (bool)sendingForm.cancelInit;

          recentlyUsedStatuses = (List<Status>)sendingForm.recentlyUsedStatuses;
          this.Text = "Basic Battle Tracker - " + Program.activeSessionName;
          turnLabel.Text = combatRound.ToString();
          if (activeIndex < combatants.Count)
          {
              activeLabel.Text = combatants.ElementAt(activeIndex).Name;
              updateFighterInfo(activeIndex);
              unholdButton.Text = "Unhold " + selectedFighterObject.Name;
          }
              UpdateFighterList();
              
          
          session.SetDirty(false);
           
               

                     }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveSessionAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            session.SaveSession(true);
        }

        private void addPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPCFunction();
        }

        private void alexToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //Remove Fighter menu option
        private void SubMenuClick(object sender, ToolStripItemClickedEventArgs e)
        {
            string clickedItem = e.ClickedItem.Text;
            Fighter removeFighter = null;
            foreach (Fighter f in combatants)
            {
                if (f.Name == clickedItem)
                {
                    removeFighter = f;
                }
            }
            if (removeFighter == null)
            {
                MessageBox.Show("Could not find the Selected Fighter in active combatants. This is likely a programming issue. Please report it.", "Oops!");
            }
            else
            {
                RemoveSelectedFighter(removeFighter);
            }

        }

        private void removeCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void addNPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNPCFunction();
        }

        private void editMenuClick(object sender, ToolStripItemClickedEventArgs e)
        {
            string clickedItem = e.ClickedItem.Text;
            Fighter editFighter = null;
            foreach (Fighter f in combatants)
            {
                if (f.Name == clickedItem)
                {
                    editFighter = f;
                }
            }
            if (editFighter == null)
            {
                MessageBox.Show("Could not find the Selected Fighter in active combatants. This is likely a programming issue. Please report it.", "Oops!");
            }
            else
            {
                EditSelectedFighter(editFighter);
            }
        }

        private void SetToFirstTurn()
        {
            combatRound = 0;
            AdvanceFighter();
        }

        private void rollInitiativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RollInit();
            AutoSave();
        }

        private void nextTurnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdvanceFighter();
            AutoSave();
        }

        private void previousTurnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreviousFigher();
            AutoSave();
        }

        private void setToTurn1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetToFirstTurn();
        }
    }


}
