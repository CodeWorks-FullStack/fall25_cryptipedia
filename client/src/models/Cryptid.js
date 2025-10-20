import { Profile } from "./Account.js"

export class Cryptid {
  constructor(data) {
    this.id = data.id
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.name = data.name
    this.description = data.description
    this.threatLevel = data.threatLevel
    this.size = data.size
    this.origin = data.origin
    this.discoverer = new Profile(data.discoverer)
    this.discovererId = data.discovererId
    this.imgUrl = data.imgUrl
  }
}