using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : BuildingBase,IUpgrade
{   
    
    protected TurretArgs turretArgs;
    protected EffectArgs effectArgs;

    protected ProjectileArgs projectileArgs;

    protected ScriptableProjectile scriptableProjectile;

    protected UpgradeType upgradeType;
    public enum UpgradeType{
        cooldown,
        projectileNum,
        range,
    }
    bool canGetEXP = true;

    int turretLevel;
    Transform target;
    protected float cooldownTimer;

    int ExperiencePoint;

    public int experiencePoint{
        get{
            return this.ExperiencePoint;
        }
        set{
            this.ExperiencePoint = value;
        }
    }

    ScriptableChoiceNode CurrentChoiceNode;

    public ScriptableChoiceNode currentChoiceNode{
        get{
            return this.CurrentChoiceNode;
        }
        set{
            this.CurrentChoiceNode = value;
        }
    }

    public void GainExp(int v){
        if (!canGetEXP) return;
        experiencePoint += v;
        Debug.Log($"{experiencePoint},{canGetEXP}");
        if(experiencePoint >= 2){
            LevelUp();
            //experiencePoint = 0;
        }
    }

    public void LevelUp(){
        Debug.Log("level up");
        Time.timeScale=0;
       
        UpgradePanelUI.Instance.openPanel(currentChoiceNode.left, currentChoiceNode.right , this);
        
    }

    public void Upgrade_(ScriptableChoiceNode nextNode){
        currentChoiceNode = nextNode;
        if(buildingName == "Slingshot"){
            if( currentChoiceNode.choiceArgs.key == "01000"){ //atk_1
                turretArgs.attackPower += 3;
            }
            else if( currentChoiceNode.choiceArgs.key == "01001"){ //atk_2
                turretArgs.attackPower += 3;
            }

            else if( currentChoiceNode.choiceArgs.key == "01002"){ //atk_3
                turretArgs.attackPower += 3;
            }

            else if( currentChoiceNode.choiceArgs.key == "01003"){ //fire_rate_1
                turretArgs.cooldown *= 0.8f;
            }

            else if( currentChoiceNode.choiceArgs.key == "01004"){ //fire_rate_2
                turretArgs.cooldown *= 0.8f;
            }

            else if( currentChoiceNode.choiceArgs.key == "01005"){ //fire_rate_3
                turretArgs.cooldown *= 0.8f;
            }
            else if( currentChoiceNode.choiceArgs.key == "01006"){
                effectArgs.splashRange = 2;
                turretArgs.attackPower += 5;
            }

            else if( currentChoiceNode.choiceArgs.key == "01007"){ 
                turretArgs.attackPower += 3;
            }

            else if( currentChoiceNode.choiceArgs.key == "01008"){ 
                turretArgs.attackPower += 3;
            }


            else if( currentChoiceNode.choiceArgs.key == "01009"){ 
                turretArgs.attackPower += 3;
            }

            else if( currentChoiceNode.choiceArgs.key == "01010"){ 
                effectArgs.splashRange += 1;
            }

            else if( currentChoiceNode.choiceArgs.key == "01010"){ 
                effectArgs.splashRange += 1;
            }

            else if( currentChoiceNode.choiceArgs.key == "01011"){ 
                effectArgs.splashRange += 1;
            }

            else if( currentChoiceNode.choiceArgs.key == "01012"){ 
                effectArgs.splashRange += 1;
            }

            else if( currentChoiceNode.choiceArgs.key == "01013"){
                effectArgs.splashRange = 3;
                effectArgs.splashDuration = 3;
            }

            
            else if( currentChoiceNode.choiceArgs.key == "01014"){
                turretArgs.attackPower += 2;
            }
            else if( currentChoiceNode.choiceArgs.key == "01015"){
                turretArgs.attackPower += 2;
            }
            else if( currentChoiceNode.choiceArgs.key == "01016"){
                turretArgs.attackPower += 2;
            }

            else if( currentChoiceNode.choiceArgs.key == "01017"){
                effectArgs.splashDuration += 1;
            }
            else if( currentChoiceNode.choiceArgs.key == "01018"){
                effectArgs.splashDuration += 1;
            }
            else if( currentChoiceNode.choiceArgs.key == "01019"){
                effectArgs.splashDuration += 1;
            }

            

            

          
        }
        
        else if(buildingName == "Ballista"){

            if( currentChoiceNode.choiceArgs.key == "00000"){ //atk_1
                turretArgs.attackPower += 3;
            }
            else if( currentChoiceNode.choiceArgs.key == "00001"){ //atk_2
                turretArgs.attackPower += 3;
            }

            else if( currentChoiceNode.choiceArgs.key == "00002"){ //atk_3
                turretArgs.attackPower += 3;
            }

            else if( currentChoiceNode.choiceArgs.key == "00003"){ //fire_rate_1
                turretArgs.cooldown *= 0.8f;
            }

            else if( currentChoiceNode.choiceArgs.key == "00004"){ //fire_rate_2
                turretArgs.cooldown *= 0.8f;
            }

            else if( currentChoiceNode.choiceArgs.key == "00005"){ //fire_rate_3
                turretArgs.cooldown *= 0.8f;
            }
            
            else if (currentChoiceNode.choiceArgs.key == "00006"){ //penetrate
                projectileArgs.isPenetrated = true;
                turretArgs.attackPower += 5;
            }

            else if (currentChoiceNode.choiceArgs.key == "00007"){ 
                turretArgs.attackPower += 3;
            }

            else if (currentChoiceNode.choiceArgs.key == "00008"){ 
                turretArgs.attackPower += 3;
            }

            else if (currentChoiceNode.choiceArgs.key == "00009"){ 
                turretArgs.attackPower += 3;
            }

            else if (currentChoiceNode.choiceArgs.key == "00010"){
                turretArgs.range += 1;
            }

            else if (currentChoiceNode.choiceArgs.key == "00011"){ 
                turretArgs.range += 1;
            }
            else if (currentChoiceNode.choiceArgs.key == "00012"){ 
                turretArgs.range += 1;
            }

            else if (currentChoiceNode.choiceArgs.key == "00013"){ 
                effectArgs.knockBackForce += 50;
            }
            else if (currentChoiceNode.choiceArgs.key == "00014"){ 
                turretArgs.attackPower += 3;
            }
            else if (currentChoiceNode.choiceArgs.key == "00015"){ 
                turretArgs.attackPower += 3;
            }
            else if (currentChoiceNode.choiceArgs.key == "00016"){ 
                turretArgs.attackPower += 3;
            }
            else if (currentChoiceNode.choiceArgs.key == "00017"){ 
                effectArgs.knockBackForce += 25;
            }
            else if (currentChoiceNode.choiceArgs.key == "00018"){ 
                effectArgs.knockBackForce += 25;
            }
            else if (currentChoiceNode.choiceArgs.key == "00019"){ 
                effectArgs.knockBackForce += 25;
            }


            
        }

        else if(buildingName == "ArcherTower"){
            if( currentChoiceNode.choiceArgs.key == "02000"){ //atk_1
                turretArgs.attackPower += 3;
            }
            else if( currentChoiceNode.choiceArgs.key == "02001"){ //atk_2
                turretArgs.attackPower += 3;
            }

            else if( currentChoiceNode.choiceArgs.key == "02002"){ //atk_3
                turretArgs.attackPower += 3;
            }

            else if( currentChoiceNode.choiceArgs.key == "02003"){ //fire_rate_1
                turretArgs.cooldown *= 0.8f;
            }

            else if( currentChoiceNode.choiceArgs.key == "02004"){ //fire_rate_2
                turretArgs.cooldown *= 0.8f;
            }

            else if( currentChoiceNode.choiceArgs.key == "02005"){ //fire_rate_3
                turretArgs.cooldown *= 0.8f;
            }

            else if( currentChoiceNode.choiceArgs.key == "02006"){
                turretArgs.extraProjectileNum += 1;
            }
            else if( currentChoiceNode.choiceArgs.key == "02007"){
                turretArgs.attackPower += 3;
            }
            else if( currentChoiceNode.choiceArgs.key == "02008"){
                turretArgs.attackPower += 3;
            }
            else if( currentChoiceNode.choiceArgs.key == "02009"){
                turretArgs.attackPower += 3;
            }
            else if( currentChoiceNode.choiceArgs.key == "02010"){
                turretArgs.extraProjectileNum += 1;
            }
            else if( currentChoiceNode.choiceArgs.key == "02011"){
                turretArgs.extraProjectileNum += 1;
            }
            else if( currentChoiceNode.choiceArgs.key == "02012"){
                turretArgs.extraProjectileNum += 1;
            }

            else if( currentChoiceNode.choiceArgs.key == "02013"){
                turretArgs.shotGunAngle = 60;
                turretArgs.shotGunNum = 3 ;
            }
            else if( currentChoiceNode.choiceArgs.key == "02014"){
                turretArgs.attackPower += 3;
            }
            else if( currentChoiceNode.choiceArgs.key == "02015"){
                turretArgs.attackPower += 3;
            }
            else if( currentChoiceNode.choiceArgs.key == "02016"){
                turretArgs.attackPower += 3;
            }

            else if( currentChoiceNode.choiceArgs.key == "02017"){
                turretArgs.shotGunNum += 1 ;
            }
            else if( currentChoiceNode.choiceArgs.key == "02018"){
                turretArgs.shotGunNum += 1 ;
            }
            else if( currentChoiceNode.choiceArgs.key == "02019"){
                turretArgs.shotGunNum += 1 ;
            }
            
            
        }   

        else{
            Debug.Log($"Building Name:{buildingName} does not exist");
        }
        string left = "";
        bool leftUnlock = false;
        if (currentChoiceNode.left != null)
        {
            left = currentChoiceNode.left.choiceArgs.key;
            leftUnlock = GameDataRecorder.Instance.skillTree.IsUnlock(left);
        }
        string right = "";
        bool rightUnlock = false;
        if (currentChoiceNode.right != null)
        {
            right = currentChoiceNode.right.choiceArgs.key;
            rightUnlock = GameDataRecorder.Instance.skillTree.IsUnlock(right);
        }

        Debug.Log($"{left} {leftUnlock} / {right} {rightUnlock}");
        canGetEXP = !((left == "" && right == "") || (!leftUnlock && !rightUnlock));
        experiencePoint = 0;
    }

    public void Init()
    {
        turretLevel = 0;
        cooldownTimer = 0;
    }
    public override void SetData(ScriptableBuilngBase scirptable)
    {
        base.SetData(scirptable);
        ScriptableTurret scriptableTurret = scirptable as ScriptableTurret;
        turretArgs = scriptableTurret.turretArgs;
        scriptableProjectile = ResourceSystem.Instance.GetProjectileData(scriptableTurret.projectile);
        upgradeType = scriptableTurret.upgradeType;
        currentChoiceNode = scirptable.choiceNodeRoot;

        effectArgs = scriptableProjectile.effectArgs;
        projectileArgs = scriptableProjectile.projectileArgs;
    }
    private void Update()
    {
        if (!isActivate) return;
        if(cooldownTimer>0) cooldownTimer-=Time.deltaTime; 
        else
        {   
            Shoot();
        }
    }
    private Transform FindNearestTarget()
    {
        Transform target = null;
        float minDist = Mathf.Infinity;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, turretArgs.range, LayerMask.GetMask("Enemy"));

        foreach(Collider2D enemy in enemies)
        {
            float dist = Vector2.Distance(enemy.transform.position, transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                target = enemy.transform;
            }
        }
        return target;
    }

    private Transform FindRandomTarget(){
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, turretArgs.range, LayerMask.GetMask("Enemy"));
        if(enemies.Length == 0) return null;
        return enemies[ Random.Range(0,enemies.Length) ].transform;
    }


    // private void CoolDownShoot(){
    //     Transform target = FindNearestTarget();
    //     if(target == null) return ;
    //     if (!EnergySystem.Instance.IsEnergyEnough(turretArgs.energyPerShot)) return;
    //     ProjectileBase projectile = Instantiate(scriptableProjectile.prefab, transform.position, Quaternion.identity);
    //     projectile.SetData(scriptableProjectile, turretArgs.attackPower, projectileArgs, effectArgs );
    //     projectile.Launch(target.position - transform.position, turretArgs.range);
    //     EnergySystem.Instance.CostEnergy(turretArgs.energyPerShot);
    //     cooldownTimer = turretArgs.cooldown / (1+populationNum) ;
    // }



    // private void RangeShoot(){
    //     Transform target = FindRandomTarget();
    //     if(target == null) return ;
    //     if (!EnergySystem.Instance.IsEnergyEnough(turretArgs.energyPerShot)) return;
    //     ProjectileBase projectile = Instantiate(scriptableProjectile.prefab, transform.position, Quaternion.identity);
    //     projectile.SetData(scriptableProjectile, turretArgs.attackPower, projectileArgs, effectArgs );
    //     projectile.Launch(target.position - transform.position, turretArgs.range + 0.5f * populationNum);
    //     EnergySystem.Instance.CostEnergy(turretArgs.energyPerShot);
    //     cooldownTimer = turretArgs.cooldown;
    // }

    IEnumerator ILaunch(int num){
        for( int i = 0 ; i < num ; i++ ){
            Transform target = FindRandomTarget();
            if(target == null) break ;
            if(!EnergySystem.Instance.IsEnergyEnough(turretArgs.energyPerShot)) break;
            
            if(turretArgs.shotGunNum == 0){
                ProjectileBase projectile = Instantiate(scriptableProjectile.prefab, transform.position, Quaternion.identity);
                projectile.SetData(scriptableProjectile, turretArgs.attackPower, projectileArgs, effectArgs);
                projectile.Launch(target.position - transform.position, turretArgs.range); 
            }

            else{
                
                int half = (turretArgs.shotGunNum) / 2 ;
                int angleUnit = turretArgs.shotGunAngle/ (half * 2 );
                for(int p_num = -1*half ; p_num <= half ; p_num++){
                    if(turretArgs.shotGunNum % 2 == 0 && p_num == 0) continue;
                    Vector2 direction = Quaternion.AngleAxis(p_num * angleUnit, Vector3.forward) *(target.position - transform.position) ;

                    ProjectileBase projectile = Instantiate(scriptableProjectile.prefab, transform.position, Quaternion.identity);
                    projectile.SetData(scriptableProjectile, turretArgs.attackPower, projectileArgs, effectArgs);
                    projectile.Launch(direction, turretArgs.range);   
                }
                
               

            }
           
            
            
            EnergySystem.Instance.CostEnergy(turretArgs.energyPerShot);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void ProjectileNumShoot(){
        
        StartCoroutine(ILaunch(1+ populationNum));
        
        cooldownTimer = turretArgs.cooldown ;
    }
    private void Shoot()
    {   
        

        Transform target = FindNearestTarget();
        if (target == null) return;
        if (EnergySystem.Instance.CostEnergy(baseArgs.energyCost))
        {   
            GainExp(1);
            
            ProjectileBase projectile = Instantiate(scriptableProjectile.prefab, transform.position, Quaternion.identity);
            
            projectile.SetData(scriptableProjectile, turretArgs.attackPower, projectileArgs, effectArgs);
            //projectile.Launch(target.position - transform.position, turretArgs.range);
            StartCoroutine(ILaunch( turretArgs.extraProjectileNum + 1 ));
            cooldownTimer = turretArgs.cooldown;
        }
        
        /*
        if( upgradeType == UpgradeType.cooldown  ){
            CoolDownShoot();
        }
        if( upgradeType == UpgradeType.projectileNum  ){
            ProjectileNumShoot();
        }
        if( upgradeType == UpgradeType.range){
            RangeShoot();
        }
        */
    }


    void OnDrawGizmos()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(transform.position, turretArgs.range);
    }
}

[System.Serializable]
public struct TurretArgs
{
    public int attackPower;
    public float cooldown;
    public float range;
    public int energyPerShot;

    public int extraProjectileNum;

    public int shotGunAngle;
    public int shotGunNum;
}

