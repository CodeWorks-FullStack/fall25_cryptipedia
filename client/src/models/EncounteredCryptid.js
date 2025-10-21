import { Cryptid } from "./Cryptid.js";

export class EncounteredCryptid extends Cryptid {
  constructor(data) {
    super(data)
    this.cryptidEncounterId = data.cryptidEncounterId
    this.encounteredAt = new Date(data.encounteredAt)
  }
}