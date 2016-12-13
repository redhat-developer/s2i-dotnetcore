package com.schoolbus.client.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonCreator;
import com.schoolbus.client.model.Owner;



import io.swagger.annotations.*;
import java.util.Objects;


public class OwnerNotes   {
  
  private Integer id = null;
  private Owner owner = null;

  /**
   * Primary Key
   **/
  public OwnerNotes id(Integer id) {
    this.id = id;
    return this;
  }

  
  @ApiModelProperty(example = "null", required = true, value = "Primary Key")
  @JsonProperty("Id")
  public Integer getId() {
    return id;
  }
  public void setId(Integer id) {
    this.id = id;
  }

  /**
   **/
  public OwnerNotes owner(Owner owner) {
    this.owner = owner;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("Owner")
  public Owner getOwner() {
    return owner;
  }
  public void setOwner(Owner owner) {
    this.owner = owner;
  }


  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    OwnerNotes ownerNotes = (OwnerNotes) o;
    return Objects.equals(id, ownerNotes.id) &&
        Objects.equals(owner, ownerNotes.owner);
  }

  @Override
  public int hashCode() {
    return Objects.hash(id, owner);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class OwnerNotes {\n");
    
    sb.append("    id: ").append(toIndentedString(id)).append("\n");
    sb.append("    owner: ").append(toIndentedString(owner)).append("\n");
    sb.append("}");
    return sb.toString();
  }

  /**
   * Convert the given object to string with each line indented by 4 spaces
   * (except the first line).
   */
  private String toIndentedString(Object o) {
    if (o == null) {
      return "null";
    }
    return o.toString().replace("\n", "\n    ");
  }
}

