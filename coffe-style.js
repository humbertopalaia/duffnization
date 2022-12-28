
1
2
3
4
//Cliente.js
module.exports = class CoffeStyle {
    constructor(id, name, active, minTemperature, maxTemperature, createDate, updateDate)
    {
        this.id = id;
        this.name = name;
        this.active = active;
        this.minTemperature = minTemperature;
        this.maxTemperature = maxTemperature;
        this.createDate = createDate;
        this.updateDate = updateDate;
    }
}